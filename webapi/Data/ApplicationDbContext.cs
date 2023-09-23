using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Data.Seeds;
using webapi.Models;

namespace webapi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<MealRequestModel> MealRequests { get; set; }
        public DbSet<RestaurantModel> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserSeedConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantSeedConfiguration());

            modelBuilder.Entity<RestaurantModel>()
                .HasOne(r => r.Creator)
                .WithMany(u => u.CreatedRestaurants)
                .HasForeignKey(r => r.CreatorId);            
            
            modelBuilder.Entity<RestaurantModel>()
                .HasMany(r => r.MealRequests)
                .WithOne(mr => mr.Restaurant)
                .HasForeignKey(mr => mr.RestaurantId);

            modelBuilder.Entity<MealRequestModel>()
                .HasOne(m => m.Creator)
                .WithMany(u => u.CreatedMealRequests)
                .HasForeignKey(m => m.CreatorId);

            modelBuilder.Entity<MealRequestModel>()
                .HasMany(m => m.Companions)
                .WithMany()
                .UsingEntity("MealRequestsCompanions");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateUpdated = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

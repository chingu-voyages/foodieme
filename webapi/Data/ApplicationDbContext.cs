using Microsoft.EntityFrameworkCore;
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

            modelBuilder.Entity<RestaurantModel>()
                .HasOne(r => r.Creator)
                .WithMany(u => u.CreatedRestaurants)
                .HasForeignKey(r => r.CreatorId);

            modelBuilder.Entity<MealRequestModel>()
                .HasOne(m => m.Creator)
                .WithMany(u => u.CreatedMealRequests)
                .HasForeignKey(m => m.CreatorId);

            modelBuilder.Entity<MealRequestModel>()
                .HasMany(m => m.Companions)
                .WithMany()
                .UsingEntity("MealRequestsCompanions");
        }
    }
}

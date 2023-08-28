using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Models;

namespace webapi.Data.Seeds
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            var hasher = new PasswordHasher<UserModel>();
            var users = new List<UserModel>();
            for (int i = 1; i <= 5; i++)
            {
                var user = new UserModel
                {
                    Id = i.ToString(),
                    UserName = "user" + i,
                    NormalizedUserName = "USER" + i,
                    Email = $"user{i}@test.ca",
                    NormalizedEmail = $"USER{i}@TEST.CA",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    DateOfBirth = new DateTime(1990, 1, 1),
                    DateJoined = DateTime.UtcNow
                };
                users.Add(user);
            }
            builder.HasData(users);
            
        }
    }
}

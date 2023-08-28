using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.Constants;
using webapi.Models;

namespace webapi.Data.Seeds
{
    public class RestaurantSeedConfiguration : IEntityTypeConfiguration<RestaurantModel>
    {
        public void Configure(EntityTypeBuilder<RestaurantModel> builder)
        {
            var restaurants = new List<RestaurantModel>
            {
                new RestaurantModel
                {
                    Id = 1,
                    CreatorId = "1", // Replace with the actual user ID
                    Name = "Restaurant 1",
                    Description = "A cozy place with delicious food.",
                    Budget = "$$$",
                    Style = RestaurantStyles.Italian,
                    Address = "123 Main Street"
                },
                new RestaurantModel
                {
                    Id = 2,
                    CreatorId = "2", // Replace with the actual user ID
                    Name = "Restaurant 2",
                    Description = "Authentic flavors from around the world.",
                    Budget = "$$",
                    Style = RestaurantStyles.AsianFusion,
                    Address = "456 Elm Avenue"
                },
                new RestaurantModel
                {
                    Id = 3,
                    CreatorId = "3", // Replace with the actual user ID
                    Name = "Restaurant 3",
                    Description = "A modern atmosphere with a diverse menu.",
                    Budget = "$$$",
                    Style = RestaurantStyles.American,
                    Address = "789 Oak Street"
                },
                new RestaurantModel
                {
                    Id =4,
                    CreatorId = "4", // Replace with the actual user ID
                    Name = "Restaurant 4",
                    Description = "Experience fine dining at its best.",
                    Budget = "$$$$",
                    Style = RestaurantStyles.French,
                    Address = "101 Maple Road"
                },
                new RestaurantModel
                {
                    Id =5,
                    CreatorId = "5", // Replace with the actual user ID
                    Name = "Restaurant 5",
                    Description = "Savor the taste of authentic sushi.",
                    Budget = "$$",
                    Style = RestaurantStyles.Japanese,
                    Address = "222 Pine Lane"
                }
            };

            builder.HasData(restaurants);

        }
    }
}

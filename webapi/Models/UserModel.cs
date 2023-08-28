using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class UserModel: IdentityUser
    {
        [NotMapped]
        public List<string>? FavouriteStyles { get; set; }
        public int? BudgetMin { get; set; }
        public int? BudgetMax { get; set; }
        public string? Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
        public List<MealRequestModel>? CreatedMealRequests { get; set; } = new();
        public List<RestaurantModel>? CreatedRestaurants { get; set; } = new();

    }
}

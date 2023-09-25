using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class UserVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public List<string>? FavouriteStyles { get; set; }
        public int? BudgetMin { get; set; }
        public int? BudgetMax { get; set; }
        public string? Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
        public List<MealRequestVM>? CreatedMealRequests { get; set; } = new();
        public List<RestaurantVM>? CreatedRestaurants { get; set; } = new();
    }
}

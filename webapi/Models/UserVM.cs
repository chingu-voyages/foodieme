namespace webapi.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
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

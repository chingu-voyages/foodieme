namespace webapi.Models
{
    public class RestaurantVM
    {
        public int Id { get; set; }
        public string? CreatorId { get; set; }
        public CreatorVM? Creator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Budget { get; set; }
        public string Style { get; set; }
        public string Address { get; set; }
        public List<MealRequestVM> MealRequests { get; set; }
    }
}

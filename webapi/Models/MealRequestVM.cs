namespace webapi.Models
{
    public class MealRequestVM
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string? CreatorName { get; set; }
        public CreatorVM? Creator { get; set; }
        public int RestaurantId { get; set; }
        public string? RestaurantName { get; set; }
        public RestaurantVM? Restaurant { get; set; }
        public List<string>? CompanionsId { get; set; }
        public List<string>? CompanionsNames { get; set; }
        public DateTime DateTime { get; set; }
        public int NumberOfPeople { get; set; }
    }
}

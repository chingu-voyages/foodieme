namespace webapi.Models
{
    public class MealRequestVM
    {
        public string CreatorId { get; set; }
        public string RestaurantId { get; set; }
        public List<string>? CompanionsId { get; set; }
        public DateTime DateTime { get; set; }
        public int NumberOfPeople { get; set; }
    }
}

namespace webapi.Models
{
    public class MealRequestCreateVM
    {
        public string CreatorId { get; set; }
        public string RestaurantId { get; set; }
        public DateTime DateTime { get; set; }
        public int NumberOfPeople { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class MealRequestModel: BaseEntity
    {
        [ForeignKey("UserId")]
        public string CreatorId { get; set; }
        public UserModel Creator { get; set; }
        [ForeignKey("RestaurantId")]
        public RestaurantModel Restaurant { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime? DateTime { get; set; }
        //public ICollection<UserModel>? Companions { get; set; } = new List<UserModel>();
        public List<UserModel>? Companions { get; set; } = new();
    }
}

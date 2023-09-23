using System.ComponentModel.DataAnnotations.Schema;
using webapi.Constants;

namespace webapi.Models
{
    public class RestaurantModel: BaseEntity
    {
        [ForeignKey("UserId")]
        public string? CreatorId { get; set; }
        public UserModel? Creator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Budget { get; set; }
        public string Style { get; set; }
        public string Address { get; set; }
        public List<MealRequestModel>? MealRequests { get; set; }
    }
}

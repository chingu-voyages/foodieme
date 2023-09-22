namespace webapi.Models
{
    public class CreatorVM
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string>? FavouriteStyles { get; set; }
        public int? BudgetMin { get; set; }
        public int? BudgetMax { get; set; }
        public string? Picture { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
    }
}

namespace BookLibrary.App.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}

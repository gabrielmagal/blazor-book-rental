using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Api.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Api.Model
{
    public class Rental
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid BookId { get; set; }
        public Book? Book { get; set; }
        public DateTime? RentalDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }
    }
}

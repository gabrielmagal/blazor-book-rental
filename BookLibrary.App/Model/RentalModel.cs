namespace BookLibrary.App.Model
{
    public class RentalModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel? User { get; set; }
        public Guid BookId { get; set; }
        public BookModel? Book { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}

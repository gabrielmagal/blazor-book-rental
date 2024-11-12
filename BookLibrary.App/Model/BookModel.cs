namespace BookLibrary.App.Model
{
    public class BookModel
    {
        public Guid Id { get; set; }
        public string? Author { get; set; }
        public float Coast { get; set; }
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}

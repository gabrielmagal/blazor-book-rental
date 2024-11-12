using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Api.Model
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string? Author { get; set; }
        public string? Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public float Coast { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MovieMania.Data
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        public IFormFile Album { get; set; }
    }
}

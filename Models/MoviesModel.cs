using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Models
{
    public class MoviesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        [NotMapped]
        public IFormFile? Album { get; set; }
    }
}

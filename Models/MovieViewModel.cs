using System.ComponentModel.DataAnnotations;

namespace MovieMania.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        public IFormFile Album { get; set; }
    }

    public class MovieEditForm
    {
        public int Id { get; set; }
    }
}

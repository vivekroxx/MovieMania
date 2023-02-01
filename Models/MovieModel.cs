using System.ComponentModel.DataAnnotations;

namespace MovieMania.Models
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string? PhotoName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class MovieViewModel : MovieModel
    {
        public bool IsFavorite { get; set; }
    }

    public class MovieCreateViewModel
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public virtual MovieDuration? Duration { get; set; }
        public IFormFile? Photo { get; set; }
    }

    public class MovieDuration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
    }

    public class MovieEditViewModel : MovieCreateViewModel
    {
        public int Id { get; set; }
        public string? ExistingPhotoPath { get; set; }
    }
}

namespace MovieMania.Models
{
    public class FavoriteMovie
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public bool IsFavorite { get; set; }
    }
}

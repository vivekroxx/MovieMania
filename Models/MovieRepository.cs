
using Microsoft.EntityFrameworkCore;

namespace MovieMania.Models
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieModel>> GetAll();
        Task<MovieModel> GetById(int id);
        Task Add(MovieModel movie);
        Task Update(MovieModel movie);
        Task Delete(int id);
    }

    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<MovieModel>> GetAll()
        {
            return await _db.Movies.ToListAsync();
        }

        public async Task<MovieModel> GetById(int id)
        {
            return await _db.Movies.FindAsync(id);
        }

        public async Task Add(MovieModel movie)
        {
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
        }

        public async Task Update(MovieModel movie)
        {
            _db.Movies.Update(movie);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var movie = await _db.Movies.FindAsync(id);
            if (movie != null)
            {
                _db.Movies.Remove(movie);
                await _db.SaveChangesAsync();
            }
        }
    }
}

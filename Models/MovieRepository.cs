
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieMania.Models
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MoviesModel>> GetAll();
        Task<MoviesModel> GetById(int id);
        Task Add(MoviesModel movie);
        Task Update(MoviesModel movie);
        Task Delete(int id);
    }

    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<MoviesModel>> GetAll()
        {
            return await _db.Movies.ToListAsync();
        }

        public async Task<MoviesModel> GetById(int id)
        {
            return await _db.Movies.FindAsync(id);
        }

        public async Task Add(MoviesModel movie)
        {
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
        }
        public async Task Update(MoviesModel movie)
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

using System.Linq;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IMovieService
    {
        IQueryable<MovieModel> Query();
        ServiceBase Create(Movie movie);
        ServiceBase Update(Movie movie);
        ServiceBase Delete(int id);
    }

    public class MovieService : ServiceBase, IMovieService
    {
        public MovieService(Db db) : base(db) { }

        public IQueryable<MovieModel> Query()
        {
            return _db.Movies.Include(m => m.Director).Select(m => new MovieModel
            {
                Id = m.Id,
                Name = m.Name,
                ReleaseDate = m.ReleaseDate,
                TotalRevenue = m.TotalRevenue,
                DirectorId = m.DirectorId,
                DirectorName = $"{m.Director.Name} {m.Director.Surname}"
            });
        }

        public ServiceBase Create(Movie movie)
        {
            if (_db.Movies.Any(m => m.Name == movie.Name.Trim()))
                return Error("Movie with the same name already exists.");

            movie.Name = movie.Name.Trim();
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return Success("Movie created.");
        }

        public ServiceBase Update(Movie movie)
        {
            var existingMovie = _db.Movies.SingleOrDefault(m => m.Id == movie.Id);
            if (existingMovie == null)
                return Error("Movie not found.");

            if (_db.Movies.Any(m => m.Name == movie.Name.Trim() && m.Id != movie.Id))
                return Error("Another movie with the same name exists.");

            existingMovie.Name = movie.Name.Trim();
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.TotalRevenue = movie.TotalRevenue;
            existingMovie.DirectorId = movie.DirectorId;

            _db.Movies.Update(existingMovie);
            _db.SaveChanges();
            return Success("Movie updated.");
        }

        public ServiceBase Delete(int id)
        {
            var movie = _db.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return Error("Movie not found.");

            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return Success("Movie deleted.");
        }
    }
}

using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class MovieService : ServiceBase, IService<Movie, MovieModel>
    {
        public MovieService(Db db) : base(db)
        {
        }

        public IQueryable<MovieModel> Query()
        {
            return _db.Movies.Include(m => m.Director).OrderByDescending( m => m.Name).ThenBy(m => m.TotalRevenue).Select(m => new MovieModel() { Record = m});
        }

        public ServiceBase Create(Movie record)
        {
            if(_db.Movies.Any(m => m.Name.ToLower() == record.Name.ToLower().Trim()))
                return Error("Movie already exists.");
            record.Name = record.Name?.Trim();
            _db.Movies.Add(record);
            _db.SaveChanges();
            return Success("Movie created.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Movies.Include(m => m.Director).SingleOrDefault(m => m.Id == id);
            if (entity == null)
                return Error("Movie not found.");
            _db.Movies.Remove(entity);
            _db.SaveChanges();
            return Success("Movie deleted.");
        }

        public ServiceBase Update(Movie record)
        {
            if(_db.Movies.Any(m => m.Name.ToLower() == record.Name.ToLower().Trim() && m.Id != record.Id))
                return Error("Movie already exists.");
            var entity = _db.Movies.SingleOrDefault(m => m.Id == record.Id);
            if (entity == null)
                return Error("Movie not found.");
            entity.Name = record.Name?.Trim();
            entity.ReleaseDate = record.ReleaseDate;
            entity.TotalRevenue = record.TotalRevenue;
            entity.DirectorId = record.DirectorId;
            entity.Genres = record.Genres;
            _db.Movies.Update(entity);
            _db.SaveChanges();
            return Success("Movie updated.");
        }
    }
}

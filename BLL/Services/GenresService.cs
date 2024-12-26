using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class GenresService : ServiceBase, IService<Genres, GenresModel>
    {
        public GenresService(Db db) : base(db)
        {
        }

        public IQueryable<GenresModel> Query()
        {
            return _db.Genres.OrderBy(g => g.Name).Select(g => new BLL.Models.GenresModel() { Record = g });
        }

        public ServiceBase Create(Genres record)
        {
            if (_db.Genres.Any(g => g.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Genre already exists.");
            record.Name = record.Name?.Trim();
            _db.Genres.Add(record);
            _db.SaveChanges();
            return Success("Genre created.");
        }
        public ServiceBase Update(Genres record)
        {
            if (_db.Genres.Any(g => g.Name.ToUpper() == record.Name.ToUpper().Trim() && g.Id != record.Id))
                return Error("Genre already exists.");
            var entity = _db.Genres.SingleOrDefault(g => g.Id == record.Id);
            if (entity == null)
                return Error("Genre not found.");
            entity.Name = record.Name?.Trim();
            _db.Genres.Update(entity);
            _db.SaveChanges();
            return Success("Genre updated.");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Genres.Include(g => g.Movies).SingleOrDefault(g => g.Id == id);
            if (entity == null)
                return Error("Genre not found.");
            if (entity.Movies.Any())
                return Error("Genre is in use.");
            _db.Genres.Remove(entity);
            _db.SaveChanges();
            return Success("Genre deleted.");
        }
    }
}

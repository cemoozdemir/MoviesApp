using System.Linq;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IDirectorService
    {
        IQueryable<DirectorModel> Query();
        ServiceBase Create(Director director);
        ServiceBase Update(Director director);
        ServiceBase Delete(int id);
    }

    public class DirectorService : ServiceBase, IDirectorService
    {
        public DirectorService(Db db) : base(db) { }

        public IQueryable<DirectorModel> Query()
        {
            return _db.Directors.Select(d => new DirectorModel
            {
                Id = d.Id,
                Name = d.Name,
                Surname = d.Surname,
                IsRetired = d.IsRetired
            });
        }

        public ServiceBase Create(Director director)
        {
            if (_db.Directors.Any(d => d.Name == director.Name && d.Surname == director.Surname))
                return Error("Director already exists.");

            director.Name = director.Name.Trim();
            director.Surname = director.Surname.Trim();
            _db.Directors.Add(director);
            _db.SaveChanges();
            return Success("Director created.");
        }

        public ServiceBase Update(Director director)
        {
            var existingDirector = _db.Directors.SingleOrDefault(d => d.Id == director.Id);
            if (existingDirector == null)
                return Error("Director not found.");

            if (_db.Directors.Any(d => d.Name == director.Name && d.Surname == director.Surname && d.Id != director.Id))
                return Error("Another director with the same name and surname exists.");

            existingDirector.Name = director.Name.Trim();
            existingDirector.Surname = director.Surname.Trim();
            existingDirector.IsRetired = director.IsRetired;

            _db.Directors.Update(existingDirector);
            _db.SaveChanges();
            return Success("Director updated.");
        }

        public ServiceBase Delete(int id)
        {
            var director = _db.Directors.Include(d => d.Movies).SingleOrDefault(d => d.Id == id);
            if (director == null)
                return Error("Director not found.");

            if (director.Movies.Any())
                return Error("Cannot delete director with associated movies.");

            _db.Directors.Remove(director);
            _db.SaveChanges();
            return Success("Director deleted.");
        }
    }
}

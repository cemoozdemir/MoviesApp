using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL.Services
{
    public class DirectorService : ServiceBase, IService<Director, DirectorModel>
    {
        public DirectorService(Db db) : base(db)
        {
        }

        public IQueryable<DirectorModel> Query()
        {
            return _db.Directors.Include(d => d.Movies).OrderByDescending(d => d.IsRetired).ThenBy(d => d.Name).ThenBy(d => d.Surname).Select(d => new DirectorModel() { Record = d });
        }

        public ServiceBase Create(Director record)
        {
            if (_db.Directors.Any(d => d.Name.ToLower() == record.Name.ToLower().Trim() && d.Surname.ToLower().Trim() == record.Surname.ToLower().Trim()))
                return Error("This Director already exists.");
            _db.Directors.Add(record);
            _db.SaveChanges();
            return Success("Director added.");
        }

        public ServiceBase Delete(int id)
        {
            var rec = _db.Directors.Include(d => d.Movies).SingleOrDefault(d => d.Id == id);
            if (rec == null)
                return Error("Director not found.");
            if (rec.Movies.Any())
                return Error("Director has movie records.");
            _db.Directors.Remove(rec);
            _db.SaveChanges();
            return Success("Director deleted.");
        }

        public ServiceBase Update(Director record)
        {
            if (_db.Directors.Any(d => d.Id != record.Id && d.Name.ToLower() == record.Name.ToLower().Trim()))
                return Error("This Director already exists.");
            var rec = _db.Directors.SingleOrDefault(d => d.Id == record.Id);
            if (rec is null)
                return Error("Director not found.");
            rec.Name= record.Name.Trim();
            rec.Surname= record.Surname.Trim();
            rec.IsRetired= record.IsRetired;
            _db.Directors.Update(rec);
            _db.SaveChanges();
            return Success("Director updated.");
        }
    }
}

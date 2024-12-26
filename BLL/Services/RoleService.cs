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
    public class RoleService : ServiceBase, IService<Role, RoleModel>
    {
        public RoleService(Db db) : base(db)
        {
        }

        public IQueryable<RoleModel> Query()
        {
            return _db.Roles.OrderBy(r => r.Name).Select(r => new RoleModel { Record = r });
        }

        public ServiceBase Create(Role record)
        {
            if (_db.Roles.Any(r => r.Name.ToLower() == record.Name.ToLower().Trim()))
                return Error("This Role already exists.");
            record.Name = record.Name.Trim();
            _db.Roles.Add(record);
            _db.SaveChanges();
            return Success("Director added.");
        }

        public ServiceBase Delete(int id)
        {
            var role = _db.Roles.Include(r => r.Users).SingleOrDefault(r => r.Id == id);
            if (role is null)
                return Error("Role not found.");
            if (role.Users.Any())
                return Error("Role has user records.");

            _db.Roles.Remove(role);
            _db.SaveChanges();
            return Success("Role deleted.");
        }

        public ServiceBase Update(Role record)
        {
            if (_db.Roles.Any(r => r.Id != record.Id && r.Name.ToLower() == record.Name.ToLower().Trim()))
                return Error("This Role already exists.");
            var role = _db.Roles.SingleOrDefault(r => r.Id == record.Id);
            if (role is null)
                return Error("Role not found.");
            role.Name = record.Name.Trim();
            _db.Roles.Update(role);
            _db.SaveChanges();
            return Success("Role updated.");
        }
    }
}

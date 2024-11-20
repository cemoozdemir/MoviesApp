using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users{ get; set; }

        public Db(DbContextOptions options) : base(options)
        {
        }
    }
}

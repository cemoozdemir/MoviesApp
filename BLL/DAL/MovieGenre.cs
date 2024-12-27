using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    public class MovieGenre
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public int GenreId { get; set; }

        // Navigation Properties
        [ForeignKey("MovieId")]
        [InverseProperty("MovieGenres")]
        public Movie Movie { get; set; }

        [ForeignKey("GenreId")]
        [InverseProperty("MovieGenres")]
        public Genres Genres { get; set; }
    }
}

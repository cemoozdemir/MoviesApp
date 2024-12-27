using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DAL
{
    public class Genres
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty("Genres")]
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}

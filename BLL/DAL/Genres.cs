using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Genres
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}

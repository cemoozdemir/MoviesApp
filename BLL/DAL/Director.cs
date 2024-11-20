using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public bool IsRetired { get; set; }

        // Navigation Property for Movies directed by this Director
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}

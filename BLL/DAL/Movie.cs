using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.DAL
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        public DateTime? ReleaseDate { get; set; }
        
        [Required]
        public decimal TotalRevenue { get; set; }
        
        [Required]
        public int DirectorId { get; set; }

        //ForeignKey
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }

        // Navigation Property for MovieGenre (Many-to-Many with Genre)
        [InverseProperty("Movie")]
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}

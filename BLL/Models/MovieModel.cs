using BLL.DAL;

namespace BLL.Models
{
    public class MovieModel
    {
        // The Record property encapsulates the existing properties
        public Movie Record => new Movie
        {
            Id = Id,
            Name = Name,
            ReleaseDate = ReleaseDate,
            TotalRevenue = TotalRevenue,
            DirectorId = DirectorId
        };

        // Existing properties
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal TotalRevenue { get; set; }
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
    }
}
 
using BLL.DAL;

namespace BLL.Models
{
    public class MovieModel
    {
        public Movie Record { get; set; }

        public string Name => Record.Name;

        public string ReleaseDate => Record.ReleaseDate.HasValue ? Record.ReleaseDate.Value.ToString("MM/dd/yyyy") : string.Empty;

        public string TotalRevenue => Record.TotalRevenue.ToString("C2");

        public string Director => $"{Record.Director?.Name} {Record.Director?.Surname}";

        public string MovieGenres => string.Join("<br>", Record.Genres?.Select(g => g.Movies));
    }
}
 
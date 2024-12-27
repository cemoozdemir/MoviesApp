using System.ComponentModel.DataAnnotations;
using BLL.DAL;

namespace BLL.Models
{
    public class MovieModel
    {
        public Movie Record { get; set; }

        [Display(Name = "Movie Name")]
        public string Name => Record.Name;

        [Display(Name ="Release Date")]
        public string ReleaseDate => Record.ReleaseDate.HasValue ? Record.ReleaseDate.Value.ToString("MM/dd/yyyy") : string.Empty;

        [Display(Name = "Total Revenue")]
        public string TotalRevenue => Record.TotalRevenue.ToString("C2");

        [Display(Name = "Movie Director")]
        public string Director => $"{Record.Director?.Name} {Record.Director?.Surname}";

        [Display(Name = "Genres")]
        public string MovieGenres => string.Join("<br>", Record.MovieGenres?.Select(g => g.Genres?.Name));

        [Display(Name = "Movie Genres")]
        public List<int> GenreIds
        {
            get => Record.MovieGenres?.Select(mg => mg.GenreId).ToList();
            set => Record.MovieGenres = value.Select(id => new MovieGenre() { GenreId = id }).ToList();

        }
    }
}
 
using System.ComponentModel.DataAnnotations;
using System.IO;
using BLL.DAL;

namespace BLL.Models
{
    public class DirectorModel
    {
        public Director Record { get; set; }

        [Display(Name = "Director Name")]
        public string Name => Record.Name;

        [Display(Name = "Director Surname")]
        public string Surname => Record.Surname;

        [Display(Name = "Retirement Status")]
        public string IsRetired => Record.IsRetired ? "Yes" : "No";

        [Display(Name = "Director's Movies")]
        public string Movies => string.Join("<br>", Record.Movies.Select(m => m.Name));
    }
}

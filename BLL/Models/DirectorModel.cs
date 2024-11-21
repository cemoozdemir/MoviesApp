using System.IO;
using BLL.DAL;

namespace BLL.Models
{
    public class DirectorModel
    {
        public Director Record { get; set; }

        public string Name => Record.Name;
        public string Surname => Record.Surname;
        public string IsRetired => Record.IsRetired ? "Yes" : "No";
        public string Movies => string.Join("<br>", Record.Movies.Select(m => m.Name));

        public string Developer { get; set; }
    }
}

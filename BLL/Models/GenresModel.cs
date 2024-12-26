using System.ComponentModel.DataAnnotations;
using BLL.DAL;

namespace BLL.Models
{
    public class GenresModel
    {
        public Genres Record { get; set; }

        [Display(Name = "Genre Name")]
        public string Name => Record.Name;
    }
}

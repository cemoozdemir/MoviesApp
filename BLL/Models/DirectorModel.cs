using BLL.DAL;

namespace BLL.Models
{
    public class DirectorModel
    {
        // The Record property encapsulates the existing properties
        public Director Record => new Director
        {
            Id = Id,
            Name = Name,
            Surname = Surname,
            IsRetired = IsRetired
        };

        // Existing properties
        public int Id { get; set; }
        public string FullName => $"{Name} {Surname}";
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsRetired { get; set; }
    }
}

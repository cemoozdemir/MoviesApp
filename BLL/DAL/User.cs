using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        // Navigation Property for Role
        public Role Role { get; set; }
    }
}

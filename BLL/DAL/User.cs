using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        [StringLength(50, ErrorMessage = "Username must be maximum {1} characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [StringLength(50, ErrorMessage = "{0} must be maximum {1} characters")]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        // Navigation Property for Role
        public Role Role { get; set; }
    }
}

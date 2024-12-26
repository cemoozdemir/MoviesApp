using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DAL;

namespace BLL.Models
{
    public class UserModel
    {
        public User Record { get; set; }

        [Display(Name = "Username")]
        public string Username => Record.Username;

        [Display(Name = "Password")]
        public string Password => Record.Password;

        public string IsActive => Record.IsActive ? "Yes" : "No";

        public string Role => Record.Role?.Name;
    }
}

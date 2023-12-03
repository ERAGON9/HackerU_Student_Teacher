using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackeru_Student_Teacher.ClientWPF.Models
{
    public interface IUser
    {
        // Properties
        public string UserName { get; }
        public Enums.UserRole IsTeacher { get; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Functions
        public void SetEmail(string newEmail);
        public void SetPassword(string newPassword);
    }
}

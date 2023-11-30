using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackeru_Student_Teacher.ClientWPF.Models
{
    public class User
    {
        public static int id = 0;
        public string UserName { get; }
        public Enums.UserRole IsTeacher { get; }

        private string email;
        public string Email { get { return email; } }

        private string password;
        public string Password { get { return password; } }


        public User(string userName, string email, string password, Enums.UserRole isTeacher)
        {
            UserName = userName;
            this.email = email;
            this.password = password;
            IsTeacher = isTeacher;
        }

        public void SetEmail(string newEmail)
        {
            this.email = newEmail;
        }
        public void SetPassword(string newPassword)
        {
            this.password = newPassword;
        }
    }
}

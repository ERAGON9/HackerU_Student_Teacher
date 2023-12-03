using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackeru_Student_Teacher.ClientWPF.Models
{
    public interface IUser
    {
        public string UserName { get; }
        public Enums.UserRole IsTeacher { get; }
        public string Email { get; }
        public string Password { get; }

        /*
        public User(string userName, string email, string password, Enums.UserRole isTeacher)
        {
            ++id;
            UserName = userName;
            this.email = email;
            this.password = password;
            IsTeacher = isTeacher;
        }
        */

        public void SetEmail(string newEmail);
        public void SetPassword(string newPassword);
    }
}

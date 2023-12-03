using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackeru_Student_Teacher.ClientWPF.Models
{
    public class Student : IUser
    {
        // IUser Properties
        public string UserName { get; }
        public Enums.UserRole IsTeacher { get; }

        private string email;
        public string Email { get { return email; } }

        private string password;
        public string Password { get { return password; } }

        // Student Properties


        //c'tor
        public Student(string userName, string email, string password)
        {
            UserName = userName;
            this.email = email;
            this.password = password;
            IsTeacher = Enums.UserRole.Student;
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

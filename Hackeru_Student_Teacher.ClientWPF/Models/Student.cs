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
        public string Email { get; set; }
        public string Password { get; set; }

        // Student Properties


        //C'tor
        public Student(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
            IsTeacher = Enums.UserRole.Student;
        }

        // Functions
        public void SetEmail(string newEmail)
        {
            Email = newEmail;
        }
        public void SetPassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}

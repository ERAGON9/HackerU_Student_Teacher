using Hackeru_Student_Teacher.ClientWPF.Models_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackeru_Student_Teacher.ClientWPF.Models_Connect
{
    public class DeserializerUser
    {
        public string UserName { get; set; }
        public Enums.UserRole IsTeacher { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DeserializerUser(string userName, string email, string password, Enums.UserRole isTeacher)
        {
            UserName = userName;
            Email = email;
            Password = password;
            IsTeacher = isTeacher;
        }
    }

}

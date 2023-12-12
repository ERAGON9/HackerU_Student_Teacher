using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackeru_Student_Teacher.API.Models_Connect
{
    public class UserLogin
    {
        public string Email {  get; set; }
        public string Password { get; set; }

        public UserLogin(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

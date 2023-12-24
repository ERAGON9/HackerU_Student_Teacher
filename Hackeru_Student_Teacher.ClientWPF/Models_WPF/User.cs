using Hackeru_Student_Teacher.ClientWPF.Models_Connect;
using System.Data;

namespace Hackeru_Student_Teacher.ClientWPF.Models_WPF
{
    public abstract class User
    {
        // Properties
        public int Id { get; set; }
        public string? UserName { get; set; }
        public Enums.UserRole IsTeacher { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<Exam> Exams { get; set; }

        // C'tor
        protected User(string name, string email, string password, Enums.UserRole role)
        {
            UserName = name;
            Email = email;
            Password = password;
            IsTeacher = role;
            Exams = new List<Exam>();
        }
        protected User(string name, string email, string password, Enums.UserRole role, List<Exam> exams)
        {
            UserName = name;
            Email = email;
            Password = password;
            IsTeacher = role;
            Exams = exams;
        }
        protected User(DeserializerUser user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Password = user.Password;
            IsTeacher = user.IsTeacher;
            Exams = user.Exams;
        }

        // Functions:
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

namespace Hackeru_Student_Teacher.API.Models_API
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


        // C'tors
        protected User()
        {
            Exams = new List<Exam>();
        }
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

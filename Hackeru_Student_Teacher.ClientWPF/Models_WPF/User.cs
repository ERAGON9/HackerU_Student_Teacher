namespace Hackeru_Student_Teacher.ClientWPF.Models_WPF
{
    public abstract class User
    {
        // Properties
        public string UserName { get; }
        public Enums.UserRole IsTeacher { get; }
        public string Email { get; set; }
        public string Password { get; set; }
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

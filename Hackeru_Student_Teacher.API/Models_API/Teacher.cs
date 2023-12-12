namespace Hackeru_Student_Teacher.API.Models_API
{
    public class Teacher : IUser
    {
        // IUser Properties
        public string UserName { get; }
        public Enums.UserRole IsTeacher { get; }
        public string Email { get; set; }
        public string Password { get; set; }


        // Teacher Properties
        public List<Exam> Exams { get; set; }


        //C'tor
        public Teacher(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
            IsTeacher = Enums.UserRole.Teacher;
            Exams = new List<Exam>();
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
        public void AddExam(Exam exam)
        {
            Exams.Add(exam);
        }
    }
}

namespace Hackeru_Student_Teacher.ClientWPF.Models
{
    public class Teacher : IUser
    {
        // IUser Properties
        public string UserName { get; }
        public Enums.UserRole IsTeacher { get; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Teacher Properties


        //C'tor
        public Teacher(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
            IsTeacher = Enums.UserRole.Teacher;
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

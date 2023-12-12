namespace Hackeru_Student_Teacher.ClientWPF.Models_WPF
{
    public class Teacher : User
    {
        // User Properties: {UserName, IsTeacher, Email, Password, Exams} already included from Base class 'User'

        // Teacher Properties


        //C'tor
        public Teacher(string userName, string email, string password): base(userName, email, password, Enums.UserRole.Teacher)
        {}


        // Functions
        // From Base class 'User' {SetEmail(), SetPassword()}
        public void AddExam(Exam exam)
        {
            Exams.Add(exam);
        }
    }
}

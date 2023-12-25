using Hackeru_Student_Teacher.ClientWPF.Models_Connect;

namespace Hackeru_Student_Teacher.ClientWPF.Models_WPF
{
    public class Teacher : User
    {
        // User Properties: {Id, UserName, IsTeacher, Email, Password, Exams} already included from Base class 'User'

        // Teacher Properties


        //C'tors
        public Teacher() : base()
        { }
        public Teacher(string userName, string email, string password) : base(userName, email, password, Enums.UserRole.Teacher)
        { }
        public Teacher(string userName, string email, string password, List<Exam> exams) : base(userName, email, password, Enums.UserRole.Teacher, exams)
        { }
        public Teacher(DeserializerUser user) : base(user)
        { }


        // Functions
        // From Base class 'User' {SetEmail(), SetPassword()}
        public void AddExam(Exam exam)
        {
            Exams.Add(exam);
        }
    }
}

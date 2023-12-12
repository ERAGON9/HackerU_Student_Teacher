using System.Data.SqlTypes;

namespace Hackeru_Student_Teacher.ClientWPF.Models_WPF
{
    public class Student : User
    {
        // User Properties: {UserName, IsTeacher, Email, Password, Exams} already included from Base class 'User'

        // Student Properties:
        public double AvgGrade { get; set; } = 0.0;


        // C'tor:
        public Student(string userName, string email, string password): base(userName,email,password, Enums.UserRole.Student)
        {}


        // Functions:
        // From Base class 'User' {SetEmail(), SetPassword()}
        public void SetAvgGrade(List<Exam> Exams)
        {
            double sum = 0.0;
            foreach(Exam exam in Exams) { sum += exam.Grade; }
            AvgGrade = sum / Exams.Count;
        }

    }
}

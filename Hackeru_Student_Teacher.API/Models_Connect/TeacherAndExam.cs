using Hackeru_Student_Teacher.API.Models_API;

namespace Hackeru_Student_Teacher.API.Models_Connect
{
    public class TeacherAndExam
    {
        public Teacher Teacher { get; set; }
        public Exam Exam { get; set; }

        public TeacherAndExam(Teacher teacher, Exam exam)
        {
            this.Teacher = teacher;
            this.Exam = exam;
        }
    }
}

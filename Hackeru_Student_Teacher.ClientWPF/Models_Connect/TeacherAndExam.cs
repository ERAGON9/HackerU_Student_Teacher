using Hackeru_Student_Teacher.ClientWPF.Models_WPF;

namespace Hackeru_Student_Teacher.ClientWPF.Models_Connect
{
    public class TeacherAndExam
    {
        public Teacher teacher { get; set; }
        public Exam exam { get; set; }

        public TeacherAndExam(Teacher teacher, Exam exam)
        {
            this.teacher = teacher;
            this.exam = exam;
        }
    }
}

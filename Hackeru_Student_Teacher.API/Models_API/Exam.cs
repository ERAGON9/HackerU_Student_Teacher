//using System.Windows.Controls;

namespace Hackeru_Student_Teacher.API.Models_API
{
    public class Exam
    {
        // Properties

        public string Name { get; set; }
        public int ExamId { get; set; }
        public string Description { get; set; }
        //public DatePicker Date { get; set; }
        public ExamTime Time { get; set; }
        public List<Question> Questions { get; set; }
        public int Grade { get; set; }
        public int QuestionNumber { get; set; } = 0;
        public bool IsRandomAnswers { get; set; }


        //C'tor
        public Exam(int examId, string name, string description, bool isRandomAnswers, /*DatePicker date,*/ int hours, int minutes)
        {
            ExamId = examId;
            Name = name;
            Description = description;
            IsRandomAnswers = isRandomAnswers;
            //Date = date;
            Time = new ExamTime(hours, minutes);
            Questions = new List<Question>();
        }


        //Functions
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
            QuestionNumber++;
        }

        public void CalculateGrade(List<Question> questions)
        {
            int sum = 0;

            foreach (Question question in questions)
            {
                if (question.ChoosenAnswer == question.CorrectAnswer)
                    sum += question.GradeTheQuestionEqual;
            }

            Grade = sum;
        }
    }
}

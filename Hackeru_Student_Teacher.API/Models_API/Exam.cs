using Microsoft.EntityFrameworkCore;

namespace Hackeru_Student_Teacher.API.Models_API
{
    public class Exam
    {
        // Properties
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateOnly Date { get; set; }
        public int Hours { get; set; } = 0;
        public int Minutes { get; set; } = 0;
        public List<Question> Questions { get; set; }
        public int Grade { get; set; }
        public int QuestionNumber { get; set; } = 0;
        public bool IsRandomAnswers { get; set; }


        //C'tor
        public Exam(string name, string description, bool isRandomAnswers, DateOnly date, int hours, int minutes)
        {
            Name = name;
            Description = description;
            IsRandomAnswers = isRandomAnswers;
            Date = date;
            Hours = hours;
            Minutes = minutes;
            Questions = new List<Question>();
        }
        public Exam()
        {
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

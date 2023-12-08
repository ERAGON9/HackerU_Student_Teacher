namespace Hackeru_Student_Teacher.ClientWPF.Models
{
    public class Exam
    {
        // Properties

        public int ExamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
        public int Grade { get; set; }
        public int QuestionNumber { get; set; } = 0;
        public bool IsRandomAnswers { get; set; }


        //C'tor
        public Exam(int examId, string name, string description, bool isRandomAnswers)
        {
            ExamId = examId;
            Name = name;
            Description = description;
            IsRandomAnswers = isRandomAnswers;
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

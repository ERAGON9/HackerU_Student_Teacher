namespace Hackeru_Student_Teacher.ClientWPF.Models
{
    public class Exam
    {
        // Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
        public int Grade { get; set; }
        public int QuestionNumber { get; set; } = 0;


        //C'tor
        public Exam(string name, string description)
        {
            Name = name;
            Description = description;
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

            //questions.ForEach(question => )
            foreach (Question question in questions)
            {
                if (question.ChoosenAnswer == question.CorrectAnswer)
                    sum += question.GradeTheQuestionEqual;
            }

            Grade = sum;
        }
    }
}

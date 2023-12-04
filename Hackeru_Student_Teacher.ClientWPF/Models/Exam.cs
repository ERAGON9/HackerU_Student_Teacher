namespace Hackeru_Student_Teacher.ClientWPF.Models
{
    public class Exam
    {
        // Properties
        public string Name { get; set; }
        public int Grade { get; set; }
        public string Description { get; set; }
        public int QuestionNumber { get; set; }

        //C'tor
        public Exam(string name, int grade, string description, int questionNumber)
        {
            Name = name;
            Grade = grade;
            Description = description;
            QuestionNumber = questionNumber;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackeru_Student_Teacher.API.Models_API
{
    public class Question
    {
        // Properties
        public int Id { get; set; }
        public string? Description { get; set; }
        public int GradeTheQuestionEqual { get; set; }
        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
        public int CorrectAnswer { get; set; } = 0; // Defult value before initialize;
        public int ChoosenAnswer { get; set; } = 0; // Defult value before initialize;

        // C'tor
        public Question(string description, int grade, string answer1, string answer2, string answer3, string answer4, int correctAnswer)
        {
            Description = description;
            GradeTheQuestionEqual = grade;
            Answer1 = answer1;
            Answer2 = answer2;
            Answer3 = answer3;
            Answer4 = answer4;
            CorrectAnswer = correctAnswer;
        }
        public Question() { }


        // Functions
        public void UpdateChoosenAnswer(int choosenNumber)
        {
            ChoosenAnswer = choosenNumber;
        }
    }
}

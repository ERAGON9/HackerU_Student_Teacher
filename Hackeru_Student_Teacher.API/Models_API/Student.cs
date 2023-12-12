﻿namespace Hackeru_Student_Teacher.API.Models_API
{
    public class Student : IUser
    {
        // IUser Properties
        public string UserName { get; }
        public Enums.UserRole IsTeacher { get; }
        public string Email { get; set; }
        public string Password { get; set; }


        // Student Properties
        public List<Exam> Exams { get; set; }
        public double AvgGrade {  get; set; }


        //C'tor
        public Student(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
            IsTeacher = Enums.UserRole.Student;
            Exams = new List<Exam>();
        }


        // Functions
        public void SetEmail(string newEmail)
        {
            Email = newEmail;
        }
        public void SetPassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}
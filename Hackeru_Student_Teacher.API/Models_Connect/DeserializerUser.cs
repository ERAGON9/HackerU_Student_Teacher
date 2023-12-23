using Hackeru_Student_Teacher.API.Models_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hackeru_Student_Teacher.API.Models_Connect
{
    public class DeserializerUser
    {
        // Properties
        public int Id { get; set; }
        public string? UserName { get; set; }
        public Enums.UserRole IsTeacher { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<Exam> Exams { get; set; }

        //C'tor
        // Constructor with JsonConstructorAttribute
        [JsonConstructor]
        public DeserializerUser(int id, string userName, Enums.UserRole isTeacher, string email, string password, List<Exam> exams)
        {
            Id = id;
            UserName = userName;
            IsTeacher = isTeacher;
            Email = email;
            Password = password;
            Exams = exams ?? new List<Exam>();
        }
        public DeserializerUser(string userName, string email, string password, Enums.UserRole role)
        {
            UserName = userName;
            Email = email;
            Password = password;
            IsTeacher = role;
            Exams = new List<Exam>();
        }
        public DeserializerUser(string userName, string email, string password, Enums.UserRole role, List<Exam> exams)
        {
            UserName = userName;
            Email = email;
            Password = password;
            IsTeacher = role;
            Exams = exams;
        }
        public DeserializerUser(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Password = user.Password;
            IsTeacher = user.IsTeacher;
            Exams = user.Exams ?? new List<Exam>(); // Ensure Exams is initialized even if null in User
        }
    }
}

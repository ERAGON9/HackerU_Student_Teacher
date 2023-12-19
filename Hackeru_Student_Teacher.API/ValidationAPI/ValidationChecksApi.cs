using Hackeru_Student_Teacher.API.DataBase;
using Hackeru_Student_Teacher.API.Models_API;
using Hackeru_Student_Teacher.API.Models_Connect;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Hackeru_Student_Teacher.ClientWPF.Progarm
{
    public class ValidationChecksApi
    {

        /// <summary>
        /// The function check when new user filling the register form he leave an empty field
        /// without filling it with necessary data.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="comboBoxRegister"></param>
        /// <returns>'true' if there is empty field after clicking 'register'
        /// or 'false' if all the fields include data.</returns>
        public static bool IsRegisterFieldsAreEmpty(string username, string email, string password, object comboBoxRegister)
        {
            if (string.IsNullOrEmpty(username))
                return true;
            if (string.IsNullOrEmpty(email))
                return true;
            if (string.IsNullOrEmpty(password))
                return true;
            if (comboBoxRegister == null)
                return true;

            return false;
        }


        /// <summary>
        /// The function check if an email adress that gotten from the user is a valid mail address,
        /// by checking it's contain '@' and '.' like all mail address must included!
        /// </summary>
        /// <param name="emailToCheck"></param>
        /// <returns>'true' if the mail is legal,
        /// or specific error message and 'false'</returns>
        public static bool EmailChecksAtAndDot(string emailToCheck)
        {
            bool validateAt = false;
            bool validateDot = false;

            foreach (char character in emailToCheck)
            {
                if (character == '@')
                    validateAt = true;
                if (character == '.')
                    validateDot = true;
            }
            if (!validateAt || !validateDot)
                return false;

            return true;
        }


        /// <summary>
        /// The function check if a password that gotten from the user is a valid password,
        /// by checking it's contain:
        /// At least 8 characters.
        /// At least 1 digit.
        /// At least 1 upper case letter.
        /// at least 1 simbol.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>'true' if the password is legal,
        /// or 'false' if the password not valid.</returns>
        public static bool LegalPassword(string password)
        {
            bool thereIsNumber = false;
            bool thereIsUpperLetter = false;
            bool thereIsSymbolchar = false;

            if (password.Length >= 8)
            {
                foreach (char character in password)
                {
                    if (char.IsDigit(character))
                    {
                        thereIsNumber = true;
                    }
                    if (char.IsUpper(character))
                    {
                        thereIsUpperLetter = true;
                    }
                    if (char.IsSymbol(character))
                    {
                        thereIsSymbolchar = true;
                    }
                }
                if (thereIsNumber && thereIsUpperLetter && thereIsSymbolchar)
                    return true;
            }
            return false;
        }

        
        /// <summary>
        /// The function check if a user that already registered before trying to register again,
        /// with thw same mail adress.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="newUser"></param>
        /// <returns>'true' is the mail not used before,
        /// or specific error message and 'false'</returns>
        public static bool ValidateIfUserAlreadyExist(List<Student> students, List<Teacher> teachers, string mailGotten)
        {
            foreach (Student student in students)
            {
                if (student.Email == mailGotten)
                    return true;
            }
            foreach (Teacher teacher in teachers)
            {
                if (teacher.Email == mailGotten)
                    return true;
            }
            return false;
        }
        

        /// <summary>
        /// The function check when new user filling the login form he leave an empty field
        /// without filling it with necessary data.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>'true' if there is empty field after clicking 'login'
        /// or 'false' if all the fields include data.</returns>
        public static bool IsLoginFieldsAreEmpty(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                return true;
            if (string.IsNullOrEmpty(password))
                return true;

            return false;
        }



        /// <summary>
        /// The function get new user data and run validation on the data, to check that the user not already exists.
        /// </summary>
        /// <param name="dataBase"></param>
        /// <param name="user"></param>
        /// <returns>'true' if all the data pass the requirements
        /// or 'false' if not.</returns>
        public static bool IsRegisterValid(DbStudentTeacher dataBase, DeserializerUser user)
        {

            // User already exists validation

            List<Student> students = dataBase.Students.ToList();
            List<Teacher> teachers = dataBase.Teachers.ToList();

            bool isUserExists = ValidateIfUserAlreadyExist(students, teachers, user.Email);
            if (isUserExists)
            {
                return false;
            }

            return true;        
        }



        /// <summary>
        /// The function get data and run validation on the data, to check all the necessary data inserted
        /// and all the data is valid to login to exists user (teacher or student) in the system.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="userLogin"></param>
        /// <returns>'true' if all the data pass the requirements
        /// or 'false' if not.</returns>
        public static bool IsLoginValid(List<User> users, LoginUser userLogin)
        {
            // Mail address gotten is belong to registered user.
            bool isUserExists = true; //ValidateIfUserAlreadyExist(users, userLogin.Email);
            if (isUserExists)
            {
                // Password gotten is equal to the password belong to the user with the mail above. 
                User? existsUser = users.FirstOrDefault(user => user.Email == userLogin.Email);
                if (existsUser.Password != userLogin.Password)
                {
                    return false; // NotFound("Incorrect password, Please try again.")
                }
                else
                    return true;
            }

            return false; //NotFound("User with this mail not exists. Please use a different email.");
        }
    }
}

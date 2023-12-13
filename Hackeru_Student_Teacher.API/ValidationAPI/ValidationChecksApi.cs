using Hackeru_Student_Teacher.API.Models_API;
using Hackeru_Student_Teacher.API.Models_Connect;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Windows;

namespace Hackeru_Student_Teacher.ClientWPF.Progarm
{
    public class ValidationChecksApi
    {
        // Example of legal mail addresses:
        //liorbarak99@gmail.com
        //liorbaa@mta.ac.il


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
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
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
        public static bool ValidateIfUserAlreadyExist(List<User> users, string mailGotten)
        {
            foreach (User user in users)
            {
                if (user.Email == mailGotten)
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
        /// 
        /// </summary>
        /// <param name="users"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsRegisterValid(List<User> users, DeserializerUser user)
        {

            // User already exists validation
            bool isUserExists = ValidateIfUserAlreadyExist(users, user.Email);
            if (isUserExists)
            {
                return false;
            }

            return true;        
        }
        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="users"></param>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public static bool IsLoginValid(List<User> users, LoginUser userLogin)
        {
            // Mail address gotten is belong to registered user.
            bool isUserExists = ValidateIfUserAlreadyExist(users, userLogin.Email);
            if (isUserExists)
            {
                // Password gotten is equal to the password belong to the user with the mail above. 
                User existsUser = users.FirstOrDefault(user => user.Email == userLogin.Email);
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

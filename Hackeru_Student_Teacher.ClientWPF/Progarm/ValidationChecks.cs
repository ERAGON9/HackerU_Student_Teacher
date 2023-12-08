using Hackeru_Student_Teacher.ClientWPF.Models;
using System.Windows;
using System.Windows.Controls;

namespace Hackeru_Student_Teacher.ClientWPF.Progarm
{
    public class ValidationChecks
    {
        // Example of legal mail addresses:
        //liorbarak99@gmail.com
        //liorbaa@mta.ac.il


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
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The function check if a user that already registered before trying to register again,
        /// with thw same mail adress.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="newUser"></param>
        /// <returns>'true' is the mail not used before,
        /// or specific error message and 'false'</returns>
        public static bool ValidateIfUserAlreadyExist(List<IUser> users, string mailGotten)
        {
            foreach (IUser user in users)
            {
                if (user.Email == mailGotten)
                {
                    return true;
                }
            }
            return false;
        }

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
        /// 
        /// </summary>
        /// <param name="users"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsRegisterValid(List<IUser> users, string username, string email, string password, object comboBoxRegister)
        {
            // Empty fields validation
            bool isEmptyFields = IsRegisterFieldsAreEmpty(username, email, password, comboBoxRegister);
            if (isEmptyFields)
            {
                MessageBox.Show("Invalid fields format. Please fill all the fields and your status (teacher/student) to register.");
                return false;
            }

            // Mail validation
            bool isMailValid = EmailChecksAtAndDot(email);
            if (!isMailValid)
            {
                MessageBox.Show("Invalid email format. Please enter a valid email address. (Include '@' and '.')");
                return false;
            }

            // Password validation
            bool isPasswordValid = LegalPassword(password);
            //bool passwordCheck = true;   // delete later, easier for debuging like this
            if (!isPasswordValid)
            {
                MessageBox.Show("Invalid password format. Please enter a valid password that incluse: more than 8 characters, a digit, an upper case letter and a symbol(special character).");
                return false;
            }

            // User already exists validation
            bool isUserExists = ValidateIfUserAlreadyExist(users, email);
            if (isUserExists)
            {
                MessageBox.Show("User with this email already exists. Please use a different email.");
                return false;
            }

            return true;        
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsLoginValid(List<IUser> users, string email, string password)
        {
            // Empty fields validation
            bool isEmptyFields = IsLoginFieldsAreEmpty(email, password);
            if (isEmptyFields)
            {
                MessageBox.Show("Invalid fields format. Please fill all the fields to login.");
                return false;
            }

            // Mail validation
            bool IsmailValid = EmailChecksAtAndDot(email);
            if (!IsmailValid)
            {
                MessageBox.Show("Invalid email format, please try again.");
                return false;
            }

            // User mail address registered
            bool isUserExists = ValidateIfUserAlreadyExist(users, email);
            if (!isUserExists)
            {
                MessageBox.Show("User with this mail not exists. Please use a different email.");
                return false;
            }

            // User password correct
            IUser existsUser = users.FirstOrDefault(user => user.Password == password);
            if (existsUser == null)
            {
                MessageBox.Show("Incorrect password, Please try again.");
                return false;
            }

            return true;
        }

    }
}

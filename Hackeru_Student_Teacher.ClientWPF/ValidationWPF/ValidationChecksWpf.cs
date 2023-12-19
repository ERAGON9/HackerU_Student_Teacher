using Hackeru_Student_Teacher.ClientWPF.Models_WPF;
using System.Windows;
using System.Windows.Controls;

namespace Hackeru_Student_Teacher.ClientWPF.Progarm
{
    public class ValidationChecksWpf
    {

        /// <summary>
        /// The function check when new user filling the register form, if he leaves an empty field
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
        /// The function check if a mail address that gotten from the user is a valid mail address,
        /// by checking it's contain '@' and '.'. (all mail addresses must include!)
        /// </summary>
        /// <param name="emailToCheck"></param>
        /// <returns>'true' if the mail is legal,
        /// or 'false' if the mail not valid.</returns>
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
        /// The function check when new user filling the login form, he leaved an empty field
        /// without filling it with necessary data.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>'true' if there is empty field after clicking 'login'
        /// or 'false' if all the fields included data.</returns>
        public static bool IsLoginFieldsAreEmpty(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                return true;
            if (string.IsNullOrEmpty(password))
                return true;

            return false;
        }


        /// <summary>
        /// The function get new user data and run validation on the data, to check all the necessary data inserted
        /// and all the data is valid to create new user (teacher or student) to the system.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>'true' if all the data pass the requirements
        /// or 'false' if not.</returns>
        public static bool IsRegisterValid(string username, string email, string password, object comboBoxRegister)
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
            if (!isPasswordValid)
            {
                MessageBox.Show("Invalid password format. Please enter a valid password that incluse: more than 8 characters, a digit, an upper case letter and a symbol(special character).");
                return false;
            }

            return true;        
        }


        /// <summary>
        /// The function get data and run validation on the data, to check all the necessary data inserted
        /// and all the data is valid to login to exists user (teacher or student) in the system.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>'true' if all the data pass the requirements
        /// or 'false' if not.</returns>
        public static bool IsLoginValid(string email, string password)
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

            // Password validation
            bool isPasswordValid = LegalPassword(password);
            if (!isPasswordValid)
            {
                MessageBox.Show("Invalid password format. Please enter a valid password that incluse: more than 8 characters, a digit, an upper case letter and a symbol(special character).");
                return false;
            }

            return true;
        }
    }
}

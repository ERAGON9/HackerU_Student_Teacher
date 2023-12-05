using Hackeru_Student_Teacher.ClientWPF.Models;
using System.Windows;

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
        public static bool ValidateIfUserAlreadyExist(List<IUser> users, string mailgotten)
        {
            foreach (IUser user in users)
            {
                if (user.Email == mailgotten)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsFieldsAreEmpty(string username, string email, string password)
        {
            if (string.IsNullOrEmpty(username))
                return true;
            if (string.IsNullOrEmpty(email))
                return true;
            if (string.IsNullOrEmpty(password))
                return true;

            return false;
        }
    }
}

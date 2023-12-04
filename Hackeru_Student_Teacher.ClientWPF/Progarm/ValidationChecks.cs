using System.Windows;

namespace Hackeru_Student_Teacher.ClientWPF.Progarm
{
    public class ValidationChecks
    {
        //liorbarak99@gmail.com
        //liorbaa@mta.ac.il
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
            if (!validateAt)
            {
                MessageBox.Show("Invalid mail, there is no @ at your mail!");
                return false;
            }
            if (!validateDot)
            {
                MessageBox.Show("Invalid mail, there is no . at your mail!");
                return false;
            }

            return true;
        }


    }
}

using Hackeru_Student_Teacher.ClientWPF.Models;
using Hackeru_Student_Teacher.ClientWPF.Progarm;
using System.Windows;
using Hackeru_Student_Teacher.ClientWPF.Pages;
using Hackeru_Student_Teacher.ClientWPF.Views;
namespace Hackeru_Student_Teacher.ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //List<IUser> users = new List<IUser>();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Get data from UI
            string username = tbUserNameRegister.Text;
            string email = tbEmailRegister.Text;
            string password = tbPasswordRegister.Password;
            Enums.UserRole role;

            if (comboBoxRegister.Text == "1")
                role = Enums.UserRole.Teacher;
            else
                role = Enums.UserRole.Student;

            bool mailCheck = ValidationChecks.EmailChecksAtAndDot(email);
            if (mailCheck)
            {
                if (role is Enums.UserRole.Student)
                {
                    IUser newUser = new Student(username, email, password);
                }
                else
                {
                    IUser newUser = new Teacher(username, email, password);
                }

                // Add newUser to a list of students! \ add messege box "user registerd" \ validate if user already registered

            }
        }

        //btn login to teacher\student window

        private void ShowPasswordLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Entered Password: {tbPasswordLogin.Password}");
        }

        private void ShowPasswordRegister_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Entered Password: {tbPasswordRegister.Password}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Pages.StudentPage());
        }
    }
}
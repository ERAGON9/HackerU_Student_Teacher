using Hackeru_Student_Teacher.ClientWPF.Models;
using Hackeru_Student_Teacher.ClientWPF.Progarm;
using System.Windows;
using System.Windows.Controls;

namespace Hackeru_Student_Teacher.ClientWPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for LoginRegisterPage.xaml
    /// </summary>
    public partial class LoginRegisterPage : UserControl
    {

        List<IUser> users = new List<IUser>();
        //delete later - we add them to Database.

        public LoginRegisterPage()
        {
            InitializeComponent();

            // Add Hard coded data (delete at the end)
            users.Add(new Teacher("Lior Teacher", "LiorT@gmail.com", "LiorTeacher"));
            users.Add(new Student("Lior Student", "LiorS@gmail.com", "LiorStudent"));
        }


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Get data from UI
            string username = tbUserNameRegister.Text;
            string email = tbEmailRegister.Text;
            string password = tbPasswordRegister.Password;
            Enums.UserRole role = Enums.UserRole.Student; // Default value

            bool dataValid = ValidationChecks.IsRegisterValid(users, username, email, password, comboBoxRegister.SelectedItem);

            if (dataValid)
            {
                ComboBoxItem selectedComboBoxItem = (ComboBoxItem)comboBoxRegister.SelectedItem;
                if (selectedComboBoxItem.Content.ToString() == "Teacher")
                    role = Enums.UserRole.Teacher;

                IUser newUser = role == Enums.UserRole.Student ? new Student(username, email, password) : new Teacher(username, email, password);
                
                // New user added
                users.Add(newUser);
                MessageBox.Show($"{selectedComboBoxItem.Content.ToString()} registered! \n UserName: {newUser.UserName} \n Email: {newUser.Email}");
            }

        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Get data from UI
            string email = tbEmailLogin.Text;
            string password = tbPasswordLogin.Password;

            bool dataValid = ValidationChecks.IsLoginValid(users, email, password);

            if (dataValid)
            {
                IUser existsUser = users.FirstOrDefault(user => user.Email == email && user.Password == password);

                MessageBox.Show("User found, you redirect to your workplace.");

                if (existsUser.IsTeacher == Enums.UserRole.Teacher) // Check user role
                    contentControl.Content = new TeacherPage(); // Navigate to TeacherPage.xaml
                else
                    contentControl.Content = new StudentPage(); // Navigate to StudentPage.xaml
            }

        }

        private void ShowPasswordLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Entered Password: {tbPasswordLogin.Password}");
        }

        private void ShowPasswordRegister_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Entered Password: {tbPasswordRegister.Password}");
        }


    }
}


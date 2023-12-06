using Hackeru_Student_Teacher.ClientWPF.Models;
using Hackeru_Student_Teacher.ClientWPF.Progarm;
using System.Windows;
using Hackeru_Student_Teacher.ClientWPF.Views.UserControls;
using System.Windows.Controls;
namespace Hackeru_Student_Teacher.ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IUser> users = new List<IUser>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Get data from UI
            string username = tbUserNameRegister.Text;
            string email = tbEmailRegister.Text;
            string password = tbPasswordRegister.Password;
            Enums.UserRole role = Enums.UserRole.Student; // Default value

            if (comboBoxRegister.SelectedItem != null)
            {
                ComboBoxItem selectedComboBoxItem = (ComboBoxItem)comboBoxRegister.SelectedItem;

                if (selectedComboBoxItem.Content != null && selectedComboBoxItem.Content.ToString() == "Teacher")
                    role = Enums.UserRole.Teacher;
            }
            else
                MessageBox.Show("Invalid fields format. Please fill you status (teacher/student) to register.");


            // Empty fields validation
            bool isEmptyFields = ValidationChecks.IsFieldsAreEmpty(username, email, password);

            // Mail validation
            bool mailCheck = ValidationChecks.EmailChecksAtAndDot(email);

            // Password validation
            bool passwordCheck = ValidationChecks.LegalPassword(password);
            //bool passwordCheck = true;

            if (!isEmptyFields)
            {
                if (mailCheck)
                {
                    if (passwordCheck)
                    {
                        bool userExists = ValidationChecks.ValidateIfUserAlreadyExist(users, email);

                        if (!userExists)
                        {
                            IUser newUser = role == Enums.UserRole.Student
                                ? new Student(username, email, password)
                                : new Teacher(username, email, password);

                            // New user added
                            users.Add(newUser);

                            MessageBox.Show($"User registered!" +
                                            $"\n UserName: {newUser.UserName}" +
                                            $"\n Email: {newUser.Email}");
                        }
                        else
                        {
                            MessageBox.Show("User with this email already exists. Please use a different email.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid password format. Please enter a valid password that incluse: more than 8 characters, a digit, an upper case letter and a symbol(special character).");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid email format. Please enter a valid email address.");
                }
            }
            else
            {
                MessageBox.Show("Invalid fields format. Please fill all the fields to register.");
            }
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Get data from UI
            string email = tbEmailLogin.Text;
            string password = tbPasswordLogin.Password;

            // Mail validation
            bool mailCheck = ValidationChecks.EmailChecksAtAndDot(email);

            if (mailCheck)
            {
                IUser existsUser = users.FirstOrDefault(user => user.Email == email && user.Password == password);

                if (existsUser == null)
                {
                    // User not found
                    MessageBox.Show("User not found, please check your mailaddress and password or register.");
                }
                else
                {
                    // User found
                    MessageBox.Show("User found, you redirect to your workplace.");
                    // Check user role
                    if (existsUser.IsTeacher == Enums.UserRole.Teacher)
                    {
                        // Navigate to TeacherPage.xaml
                        contentControl.Content = new TeacherPage();
                    }
                    else
                    {
                        // Navigate to StudentPage.xaml
                        contentControl.Content = new StudentPage();
                    }
                }
            }
            else
            {
                // Invalid email format
                MessageBox.Show("Invalid email format, please try again.");
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
using Hackeru_Student_Teacher.ClientWPF.Models_WPF;
using Hackeru_Student_Teacher.ClientWPF.ApiRequestorWPF;
using Hackeru_Student_Teacher.ClientWPF.Progarm;
using System.Windows;
using System.Windows.Controls;
using Hackeru_Student_Teacher.ClientWPF.Models_Connect;

namespace Hackeru_Student_Teacher.ClientWPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for LoginRegisterPage.xaml
    /// </summary>
    public partial class LoginRegisterPage : UserControl
    {
        ApiRequestor apiRequestor;

        //List<User> users = new List<User>();
        //delete later - we add them to Database.

        public LoginRegisterPage()
        {
            InitializeComponent();

            apiRequestor = new ApiRequestor();

            // Add Hard coded data (delete at the end)
            //users.Add(new Teacher("Lior Teacher", "LiorT@gmail.com", "LiorTeacher"));
            //users.Add(new Student("Lior Student", "LiorS@gmail.com", "LiorStudent"));
        }


        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Get data from UI.
            string username = tbUserNameRegister.Text;
            string email = tbEmailRegister.Text;
            string password = tbPasswordRegister.Password;
            Enums.UserRole role = Enums.UserRole.Student; // Default value

            bool dataValid = ValidationChecksWpf.IsRegisterValid(username, email, password, comboBoxRegister.SelectedItem);

            if (dataValid)
            {
                ComboBoxItem selectedComboBoxItem = (ComboBoxItem)comboBoxRegister.SelectedItem;
                if (selectedComboBoxItem.Content.ToString() == "Teacher")
                    role = Enums.UserRole.Teacher;

                //2.2) Create Object of User (Student/Teacher)
                DeserializerUser newUser;
                if (role == Enums.UserRole.Student)
                    newUser = new DeserializerUser(username, email, password, Enums.UserRole.Student);
                else
                    newUser = new DeserializerUser(username, email, password, Enums.UserRole.Teacher);

                // New user added.
                //users.Add(newUser);

                //2.3 Run Async RegisterRequestAsync and Get bool 'true' if the user added to dataBase or 'false' if not.
                bool response = await apiRequestor.RegisterRequestAsync(newUser);

                if (response) // Succes message
                    MessageBox.Show($"{selectedComboBoxItem.Content.ToString()} registered! \nUserName: {newUser.UserName} \nEmail: {newUser.Email} \nNow you can to login with your user!");
                else // Eror message
                    MessageBox.Show("User with this email already exists. Please use a different email.");

            }

        }


        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Get data from UI
            string email = tbEmailLogin.Text;
            string password = tbPasswordLogin.Password;

            bool dataValid = ValidationChecksWpf.IsLoginValid(email, password);

            if (dataValid)
            {
                //2.2) Create Object of UserLogin 
                UserLogin userLogin = new UserLogin(email, password);

                //2.3 Run Async LoginRequestAsync and Get DeserializerUser if the user exists or null if not.
                DeserializerUser returnedUser = await apiRequestor.LoginRequestAsync(userLogin);

                if (returnedUser != null)
                {
                    MessageBox.Show("User found, you redirect to your workplace.");

                    if (returnedUser.IsTeacher == Enums.UserRole.Teacher)
                        contentControl.Content = new TeacherPage();
                    else
                        contentControl.Content = new StudentPage();
                }
                else
                    MessageBox.Show("User with this mail and password not exists, please check the mail and the password and try again.");
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


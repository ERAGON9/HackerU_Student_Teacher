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
    public partial class RegisterPage : UserControl
    {
        ApiRequestor apiRequestor;

        //List<User> users = new List<User>();
        //delete later - we add them to Database.

        public RegisterPage()
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



        private void ShowPasswordRegister_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Entered Password: {tbPasswordRegister.Password}");
        }

        private void GotoLogin_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new LoginPage();
        }
    }
}


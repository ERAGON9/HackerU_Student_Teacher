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

        List<IUser> users = new List<IUser>();
        //delete later - we add them to Database.

        public LoginRegisterPage()
        {
            InitializeComponent();

            apiRequestor = new ApiRequestor();

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

            bool dataValid = ValidationChecksWpf.IsRegisterValid(users, username, email, password, comboBoxRegister.SelectedItem);

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

                //2.3 Run Async RequestLoginAsync and Get
                IUser userReturned = await apiRequestor.LoginRequestAsync(userLogin);

                if (userReturned != null)
                {

                    //IUser existsUser = users.FirstOrDefault(user => user.Email == email && user.Password == password);

                    MessageBox.Show("User found, you redirect to your workplace.");

                    if (userReturned.IsTeacher == Enums.UserRole.Teacher) // Check user role
                        contentControl.Content = new TeacherPage(); // Navigate to TeacherPage.xaml
                    else
                        contentControl.Content = new StudentPage(); // Navigate to StudentPage.xaml
                }
                else
                {
                    MessageBox.Show("User with this mail and password not exists, please check the mail and the password and try again.");
                }

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


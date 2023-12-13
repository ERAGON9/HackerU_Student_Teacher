using Hackeru_Student_Teacher.ClientWPF.ApiRequestorWPF;
using Hackeru_Student_Teacher.ClientWPF.Models_Connect;
using Hackeru_Student_Teacher.ClientWPF.Models_WPF;
using Hackeru_Student_Teacher.ClientWPF.Progarm;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Hackeru_Student_Teacher.ClientWPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        ApiRequestor apiRequestor;


        public LoginPage()
        {
            InitializeComponent();
            apiRequestor = new ApiRequestor();


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

        private void GotoRgister_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new RegisterPage();
        }
    }
}

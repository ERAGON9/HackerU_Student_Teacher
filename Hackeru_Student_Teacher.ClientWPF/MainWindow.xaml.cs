﻿using Hackeru_Student_Teacher.ClientWPF.Models;
using Hackeru_Student_Teacher.ClientWPF.Progarm;
using System.Windows;
using Hackeru_Student_Teacher.ClientWPF.Views.UserControls;
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
            Enums.UserRole role = comboBoxRegister.Text == "1" ? Enums.UserRole.Teacher : Enums.UserRole.Student;

            // Empty fields validation
            bool isEmptyFields = ValidationChecks.IsFieldsAreEmpty(username, email, password);

            // Mail validation
            bool mailCheck = ValidationChecks.EmailChecksAtAndDot(email);
            if (isEmptyFields)
            {
                if (mailCheck)
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
                        //this.NavigationService.Navigate(new TeacherPage());
                    }
                    else
                    {
                        // Navigate to StudentPage.xaml
                        //this.NavigationService.Navigate(new StudentPage());
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



        /// <summary>
        /// delete later- how to display diffrent page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //StudentPage.Content = new StudentPage();
            TeacherPage.Content = new TeacherPage();
        }
    }
}
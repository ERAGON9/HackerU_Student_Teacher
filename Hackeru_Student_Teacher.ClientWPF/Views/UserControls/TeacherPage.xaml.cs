using Hackeru_Student_Teacher.ClientWPF.Models_WPF;
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
    /// Interaction logic for TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : UserControl
    {
        List<Exam> Exams = new List<Exam>();
        public TeacherPage()
        {
            InitializeComponent();
        }

        private void newExam_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new CreateExamPage();
            //consider maybe to change it to a new window dialog?
        }



        private void editExam_Click(object sender, RoutedEventArgs e)
        {

        }


        private void examStatistics_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logged out!");
            contentControl.Content = new RegisterPage();
        }


    }
}

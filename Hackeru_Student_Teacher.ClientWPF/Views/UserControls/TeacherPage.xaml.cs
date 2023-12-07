using Hackeru_Student_Teacher.ClientWPF.Models;
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

        }

        private void addQuestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editExam_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editQuestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void examStatistics_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {


            // need to make seperate login \ register contents and navigate between them to solve (main window will be a window you wont go back to)

        }


    }
}

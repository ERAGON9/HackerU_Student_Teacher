using Hackeru_Student_Teacher.ClientWPF.Models_WPF;
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
using Hackeru_Student_Teacher.ClientWPF.Views.Windows;
using static Hackeru_Student_Teacher.ClientWPF.Views.Windows.AddQuestionWindow;

namespace Hackeru_Student_Teacher.ClientWPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CreateExamPage.xaml
    /// </summary>
    /// 
    public partial class CreateExamPage : UserControl
    {




        public CreateExamPage()
        {
            InitializeComponent();

            // Populate hours ComboBox
            for (int i = 0; i < 24; i++)
                hoursComboBox.Items.Add(i.ToString());

            // Populate minutes ComboBox
            for (int i = 0; i < 60; i++)
                minutesComboBox.Items.Add(i.ToString("D2")); // Format with leading zero
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string Name = txtExamName.Text;

            string description = Description.Text;
            bool isRandomAnswer = Random_Questions_Order.IsChecked == true;
            DatePicker date = ExamDate;

            Exam newExan = new Exam(Name, description, isRandomAnswer, int.Parse(hoursComboBox.Text), int.Parse(minutesComboBox.Text));
            // teacher.AddExam(newExan);


        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new TeacherPage();
        }


        private void addQuestion_Click(object sender, RoutedEventArgs e)
        {
            AddQuestionWindow addQuestionWindow = new AddQuestionWindow();
            addQuestionWindow.ShowDialog();


        }





    }
}

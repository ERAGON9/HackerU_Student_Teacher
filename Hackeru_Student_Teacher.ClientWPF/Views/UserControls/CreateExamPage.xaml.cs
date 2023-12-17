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

namespace Hackeru_Student_Teacher.ClientWPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for CreateExamPage.xaml
    /// </summary>
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
            DatePicker dateFromGUI = ExamDate;
            DateTime dateConvert;

            // Validation fields not empty + Name is Uniq!!!

            if (dateFromGUI.SelectedDate != null)
            {
                dateConvert = (DateTime)dateFromGUI.SelectedDate;
                DateOnly examDate = new DateOnly(dateConvert.Year, dateConvert.Month, dateConvert.Day);
                Exam newExan = new Exam(Name, description, isRandomAnswer, examDate, int.Parse(hoursComboBox.Text), int.Parse(minutesComboBox.Text));
                // teacher.AddExam(newExan);
            }
            else
            {
                // Eror no exam date entered!
            }

        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new TeacherPage();
        }
    }
}

using Hackeru_Student_Teacher.ClientWPF.ApiRequestorWPF;
using Hackeru_Student_Teacher.ClientWPF.Models_WPF;
using Hackeru_Student_Teacher.ClientWPF.Progarm;
using Hackeru_Student_Teacher.ClientWPF.Views.Windows;
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
        ApiRequestor apiRequestor;
        public Teacher CurrentTeacher { get; set; }


        public CreateExamPage(Teacher activeTeacher)
        {
            InitializeComponent();

            apiRequestor = new ApiRequestor();

            // Populate hours ComboBox
            for (int i = 0; i < 24; i++)
                hoursComboBox.Items.Add(i.ToString());

            // Populate minutes ComboBox
            for (int i = 0; i < 60; i++)
                minutesComboBox.Items.Add(i.ToString("D2")); // Format with leading zero

            CurrentTeacher = activeTeacher;
        }

        private async void Create_Click(object sender, RoutedEventArgs e)
        {
            string Name = txtExamName.Text;
            string description = Description.Text;
            bool isRandomAnswer = Random_Questions_Order.IsChecked == true;
            DatePicker dateFromGUI = ExamDate;

            // Validation fields not empty + Name is Uniq!!!
            bool dataValid = ValidationChecksWpf.IsNewExamValid(Name, description, dateFromGUI);

            if (dataValid)
            {
                DateTime dateConvert = (DateTime)dateFromGUI.SelectedDate;
                DateOnly examDate = new DateOnly(dateConvert.Year, dateConvert.Month, dateConvert.Day);
                Exam newExan = new Exam(Name, description, isRandomAnswer, examDate, int.Parse(hoursComboBox.Text), int.Parse(minutesComboBox.Text));
                CurrentTeacher.AddExam(newExan);

                bool response = await apiRequestor.AddExamAsync(newExan, CurrentTeacher);

                if (response) // Succes message
                {
                    MessageBox.Show("Exam added successfully!");
                    contentControl.Content = new TeacherPage(CurrentTeacher);
                }
                else // Eror message
                    MessageBox.Show("The exam not added, please try again.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new TeacherPage(CurrentTeacher);
        }

        private void addQuestion_Click(object sender, RoutedEventArgs e)
        {
            AddQuestionWindow addQuestionWindow = new AddQuestionWindow();
            addQuestionWindow.ShowDialog();
        }
    }
}

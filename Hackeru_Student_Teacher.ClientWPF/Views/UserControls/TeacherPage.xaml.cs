using Hackeru_Student_Teacher.ClientWPF.Models_Connect;
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
        private static Teacher CurrentTeacher { get; set; }

        private string originalText = "Search For Exam:";

        private List<string> teacherTests = new List<string>{};


        public TeacherPage(Teacher activeTeacher)
        {
            InitializeComponent();

            CurrentTeacher = activeTeacher;

            teacherTests = FillAllTests(teacherTests);

            PopulateListBox(teacherTests);

            UserName.Text = "Hello " + CurrentTeacher.UserName.ToString();
        }

        private List<string> FillAllTests(List<string> teacherTests)
        {
            foreach (Exam exam in CurrentTeacher.Exams)
                teacherTests.Add(exam.Name);

            return teacherTests;
        }

        private void newExam_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new CreateExamPage(CurrentTeacher);
        }


        private void editExam_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new EditExamPage(CurrentTeacher);
        }


        private void examStatistics_Click(object sender, RoutedEventArgs e)
        {}

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logged out!");
            contentControl.Content = new LoginPage();
        }


        private void PopulateListBox(IEnumerable<string> items)
        {
            ExamList.ItemsSource = items;
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = searchBox.Text.ToLower();

            var filteredData = string.IsNullOrWhiteSpace(searchText) ? teacherTests : teacherTests.Where(item => item.ToLower().Contains(searchText)).ToList();

            PopulateListBox(filteredData);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchBox.Text.ToLower();

            var filteredData = string.IsNullOrWhiteSpace(searchText) ? teacherTests : teacherTests.Where(item => item.ToLower().Contains(searchText)).ToList();

            PopulateListBox(filteredData);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear the text when the textbox gets focus.
            searchBox.Text = null;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                // Restore the default text if the textbox is empty on losing focus.
                searchBox.Text = originalText;
            }
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the ListBox to display the entire list.
            PopulateListBox(teacherTests);
        }

    }
}


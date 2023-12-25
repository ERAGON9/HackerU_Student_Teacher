using Hackeru_Student_Teacher.ClientWPF.Models_Connect;
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
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : UserControl
    {

        private static Student CurrentStudent { get; set; }

        private List<string> examData = new List<string>
        {
            "Apple", "Orange", "Banana", "Pineapple", "Grapes",
            "Watermelon", "Strawberry", "Kiwi", "Mango", "Peach"
        };
        private List<string> filteredExams = new List<string> { };


        public StudentPage(Student activeStudent)
        {
            InitializeComponent();
            PopulateListBox(examData);

            CurrentStudent = activeStudent;

            UserName.Text = "Hello " + CurrentStudent.UserName.ToString();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                PopulateListBox(examData);
                return;
            }

            filteredExams = examData.Where(item => item.ToLower().Contains(searchText)).ToList();
            PopulateListBox(filteredExams);
        }

        private void PopulateListBox(IEnumerable<string> items)
        {
            ExamListBox.ItemsSource = items;
        }

        private void searchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchTextBox.Text == "Search exam:")
            {
                searchTextBox.Text = "";
            }
        }

        private void searchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                searchTextBox.Text = "Search exam:";
            }
        }

        private void ShowExamsHistory_Click(object sender, RoutedEventArgs e)
        {
            //Content to exam history
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the ListBox to display the entire list
            PopulateListBox(examData);
        }

        private void ExamListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedExamListBox.Items.Clear();

            // Check if an item is selected
            if (ExamListBox.SelectedItem != null)
            {
                // Get the selected item and add it to the second ListBox
                SelectedExamListBox.Items.Add(ExamListBox.SelectedItem);
            }
        }

    }
}

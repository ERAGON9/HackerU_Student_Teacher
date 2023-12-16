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
        private List<string> examData = new List<string>
        {
            "Apple", "Orange", "Banana", "Pineapple", "Grapes",
            "Watermelon", "Strawberry", "Kiwi", "Mango", "Peach"
        };
        private List<string> filteredExams;
        public StudentPage()
        {
            InitializeComponent();
            PopulateListBox(examData);
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
    }
}

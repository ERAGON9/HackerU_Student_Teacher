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

        private string originalText = "Search For Exam:";

        private List<string> data = new List<string>
        {
            "Apple", "Orange", "Banana", "Pineapple", "Grapes",
            "Watermelon", "Strawberry", "Kiwi", "Mango", "Peach"
        };

        List<Exam> Exams = new List<Exam>();
        public TeacherPage()
        {
            InitializeComponent();
            PopulateListBox(data);

        }

        private void newExam_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new CreateExamPage();

        }



        private void editExam_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new EditExamPage();
        }


        private void examStatistics_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Logged out!");
            contentControl.Content = new LoginPage();
        }



        private void PopulateListBox(IEnumerable<string> items)
        {
            ExamList.ItemsSource = items;
        }

        private void searchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string searchText = searchBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                PopulateListBox(data);
                return;
            }

            var filteredData = data.Where(item => item.ToLower().Contains(searchText)).ToList();
            PopulateListBox(filteredData);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                PopulateListBox(data);
                return;
            }

            var filteredData = data.Where(item => item.ToLower().Contains(searchText)).ToList();
            PopulateListBox(filteredData);
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear the text when the textbox gets focus
            searchBox.Text = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                // Restore the default text if the textbox is empty on losing focus
                searchBox.Text = originalText;
            }
        }


    }

}


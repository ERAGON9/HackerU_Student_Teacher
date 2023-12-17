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
using MahApps.Metro.Controls;
using System.Windows.Shapes;
using Hackeru_Student_Teacher.ClientWPF.Models_WPF;



namespace Hackeru_Student_Teacher.ClientWPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddQuestionWindow.xaml
    /// </summary>
    public partial class AddQuestionWindow : MetroWindow
    {

        public AddQuestionWindow()
        {
            InitializeComponent();
        }

        private void Questiontb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Ex: what is the best coding language?")
            {
                textBox.Text = ""; // Clear the default text when TextBox is clicked
                textBox.Foreground = Brushes.Black; // Change text color if needed
            }
        }

        private void Questiontb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Ex: what is the best coding language?"; // Restore default text if TextBox is empty
                textBox.Foreground = Brushes.Gray; // Change text color back to placeholder color
            }
        }

        private void cancelbt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Addbt_Click(object sender, RoutedEventArgs e)
        {


        }


    }
}

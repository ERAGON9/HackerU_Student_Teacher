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
            {
                // hoursComboBox.Items.Add(i.ToString("D2")); // Format with leading zero
            }

            // Populate minutes ComboBox
            for (int i = 0; i < 60; i++)
            {
                //minutesComboBox.Items.Add(i.ToString("D2"));
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string examName = txtExamName.Text;
            int examId = int.Parse(txtExamId.Text);
            // bool isRandomAnswer = //Random_Questions_Order.IsChecked == true;
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new TeacherPage();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

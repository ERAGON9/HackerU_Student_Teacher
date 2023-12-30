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
    /// Interaction logic for EditExamPage.xaml
    /// </summary>
    public partial class EditExamPage : UserControl
    {
        public Teacher CurrentTeacher { get; set; }


        public EditExamPage(Teacher activeTeacher)
        {
            InitializeComponent();

            CurrentTeacher = activeTeacher;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new TeacherPage(CurrentTeacher);
        }
    }
}

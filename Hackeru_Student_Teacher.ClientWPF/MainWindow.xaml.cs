using Hackeru_Student_Teacher.ClientWPF.Views.UserControls;
using System.Windows;
namespace Hackeru_Student_Teacher.ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new LoginRegisterPage();
        }
    }
}
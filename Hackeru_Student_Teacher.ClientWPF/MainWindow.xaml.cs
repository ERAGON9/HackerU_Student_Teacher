using Hackeru_Student_Teacher.ClientWPF.Views.UserControls;
using MahApps.Metro.Controls;
using System.Windows;
namespace Hackeru_Student_Teacher.ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
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
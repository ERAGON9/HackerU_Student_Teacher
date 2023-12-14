using Hackeru_Student_Teacher.ClientWPF.Views.UserControls;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
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


        private void btn_Start(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new LoginPage();

        }
    }
}
using System.Windows;

namespace Hackeru_Student_Teacher.ClientWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private Mutex _mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "Student_Teacher.ClientWPF";


            _mutex = new Mutex(true, appName, out bool createdNew);

            if (!createdNew)
            {

                MessageBox.Show("Another instance of the application is already running.");
                Application.Current.Shutdown();
            }

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _mutex?.ReleaseMutex();
            _mutex?.Dispose();
            base.OnExit(e);
        }

    }

}

using System;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Create the NavigationStore
            var navigationStore = new NavigationStore();

            // Create the MainViewModel and pass the NavigationStore
            var mainViewModel = new MainViewModel(navigationStore);

            // Set the MainViewModel as the DataContext for the MainWindow
            var mainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };

            // Set the initial view (ListTourView) in the NavigationStore
            navigationStore.CurrentViewModel = new ListTourViewModel(navigationStore);

            // Show the MainWindow
            mainWindow.Show();
            log.Info("TourPlanner client has started!");
        }
    }
}

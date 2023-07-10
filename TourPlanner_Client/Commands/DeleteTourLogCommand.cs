using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class DeleteTourLogCommand : CommandBase
    {
        private readonly EditTourLogViewModel _viewModel;
        private readonly NavigationStore _navigationStore;

        public DeleteTourLogCommand(EditTourLogViewModel viewModel, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            // Delete the tour using the TourManager
            TourManager tourManager = TourManager.Instance;
            tourManager.DeleteTourLog(_viewModel);

            MessageBox.Show("TourLog deleted!");
           
            // Navigate back to the list view
            _navigationStore.CurrentViewModel = new ListTourViewModel(_navigationStore);
        }
    }
}

using System;
using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class DeleteTourCommand : CommandBase
    {
        private readonly EditTourViewModel _viewModel;
        private readonly NavigationStore _navigationStore;

        public DeleteTourCommand(EditTourViewModel viewModel, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            // Delete the tour using the TourManager
            TourManager tourManager = TourManager.Instance;
            tourManager.DeleteTour(_viewModel);

            MessageBox.Show("Tour deleted!");

            // Navigate back to the list view
            _navigationStore.CurrentViewModel = new ListTourViewModel(_navigationStore);
        }
    }
}

using System;
using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class SubmitChangeCommand : CommandBase
    {
        public EditTourViewModel ViewModel { get; set; }
        private readonly NavigationStore _navigationStore;

        public SubmitChangeCommand(EditTourViewModel viewModel, NavigationStore navigationStore)
        {
            this.ViewModel = viewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            // Update the tour in the database
            TourManager tourManager = TourManager.Instance;
            tourManager.UpdateTour(ViewModel);

            MessageBox.Show("Changes submitted!");
            _navigationStore.CurrentViewModel = new ListTourViewModel(_navigationStore);
        }
    }
}
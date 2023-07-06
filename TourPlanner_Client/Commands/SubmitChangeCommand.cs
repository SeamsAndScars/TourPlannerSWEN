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
        public ViewModelBase ViewModel { get; set; }
    
        private readonly NavigationStore _navigationStore;

        public SubmitChangeCommand(ViewModelBase viewModel, NavigationStore navigationStore)
        {
            ViewModel = viewModel;
           
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            // Determine the type of the ViewModel and handle accordingly
            if (ViewModel is EditTourViewModel tourViewModel)
            {
                // Update the tour in the database
                TourManager tourManager = TourManager.Instance;
                tourManager.UpdateTour(tourViewModel);

                MessageBox.Show("Tour changes submitted!");
            }
            else if (ViewModel is EditTourLogViewModel tourLogViewModel)
            {
                // Update the tour log in the database
                TourManager tourManager = TourManager.Instance;
                tourManager.UpdateTourLog(tourLogViewModel);

                MessageBox.Show("Tour log changes submitted!");
            }

            _navigationStore.CurrentViewModel = new ListTourViewModel(_navigationStore);
        }
    }
}
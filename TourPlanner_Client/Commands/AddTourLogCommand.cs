using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class AddTourLogCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly TourManager _tourManager;

        public ListTourViewModel ViewModel { get; set; }

        public AddTourLogCommand(ListTourViewModel viewModel, NavigationStore navigationStore, TourManager tourManager)
        {
            ViewModel = viewModel;
            _navigationStore = navigationStore;
            _tourManager = tourManager;
        }

        public override void Execute(object parameter)
        {
            if (ViewModel.SelectedTour != null)
            {
                // Retrieve the tour logs for the selected tour
                List<TourLog> tourLogs = _tourManager.GetTourLogs(ViewModel.SelectedTour);

                // Pass the tour logs to the AddTourLogViewModel
                _navigationStore.CurrentViewModel = new AddTourLogViewModel(_navigationStore, ViewModel.SelectedTour, tourLogs);
            }
            else
            {
                MessageBox.Show("No tour selected.");
            }
        }
    }
}

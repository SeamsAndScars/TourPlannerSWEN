using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class AddTourLogCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public ListTourViewModel _viewModel { get; set; }


        public AddTourLogCommand(ListTourViewModel viewModel, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedTour != null)
            {
                _navigationStore.CurrentViewModel = new AddTourLogViewModel(_navigationStore, _viewModel.SelectedTour);
            }
            else
            {
                MessageBox.Show("No tour selected.");
            }
        }
    }
}

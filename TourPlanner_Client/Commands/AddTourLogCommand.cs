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
    class AddTourLogCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public EditTourViewModel ViewModel { get; set; }


        public AddTourLogCommand(EditTourViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public AddTourLogCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Tour selectedTour)
            {
                _navigationStore.CurrentViewModel = new AddTourLogViewModel(_navigationStore, selectedTour);

            }
            else
            {
                MessageBox.Show("Invalid tour selected.");
            }
        }
    }
}

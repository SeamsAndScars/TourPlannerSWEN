using System.Windows;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;
using TourPlanner_Client.Views;

namespace TourPlanner_Client.Commands
{
    public class EditTourCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public EditTourViewModel ViewModel { get; set; }


        public EditTourCommand(EditTourViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public EditTourCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Tour selectedTour)
            {
                _navigationStore.CurrentViewModel = new EditTourViewModel(_navigationStore, selectedTour);
                
            }
            else
            {
                MessageBox.Show("Invalid tour selected.");
            }
        }
    }

}

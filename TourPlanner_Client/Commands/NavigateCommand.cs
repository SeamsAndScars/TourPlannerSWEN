using System;
using System.Windows.Controls;
using System.Windows.Input;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (parameter is Tour selectedTour)
            {
                // Check if the selected tour is null or has an empty ID (indicating it's a new tour)
                if (selectedTour == null || selectedTour.Id == Guid.Empty)
                {
                    // Create the AddTourViewModel and set it as the current view model in the NavigationStore
                    var addTourViewModel = new AddTourViewModel(_navigationStore);
                    _navigationStore.CurrentViewModel = addTourViewModel;
                }
                else
                {
                    // Create the EditTourViewModel and pass the selected tour item
                    var editTourViewModel = new EditTourViewModel(_navigationStore, selectedTour);
                    _navigationStore.CurrentViewModel = editTourViewModel;
                }
            }
        }
    }
}

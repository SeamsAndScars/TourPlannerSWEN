using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner_Client.BL;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;

namespace TourPlanner_Client.ViewModels
{
    internal class AddTourLogViewModel : ViewModelBase
    {
        private TourManager tourManager;
        private Tour tour;
        private ObservableCollection<Tour> tours;
        public ObservableCollection<Tour> Tours
        {
            get { return tours; }
            set
            {
                tours = value;
                OnPropertyChanged(nameof(Tours));
            }
        }

        private NavigationStore navigationStore;
        public NavigationStore NavigationStore
        {
            get { return navigationStore; }
            set
            {
                navigationStore = value;
                OnPropertyChanged(nameof(NavigationStore));
            }
        }

        private Tour selectedTour;
        public Tour SelectedTour
        {
            get { return selectedTour; }
            set
            {
                selectedTour = value;
                OnPropertyChanged(nameof(SelectedTour));
            }
        }
        public CancelTourCommand CancelTourCommand { get; }

        public AddTourLogViewModel(NavigationStore navigationStore, Tour selectedTour)
        {

            this.navigationStore = navigationStore;
            tour = selectedTour;
            CancelTourCommand = new CancelTourCommand(navigationStore);
        }

    }
}

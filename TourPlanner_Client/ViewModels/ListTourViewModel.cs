using System.Collections.Generic;
using System.Collections.ObjectModel;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.BL;
using System.Windows.Data;

namespace TourPlanner_Client.ViewModels
{
    public class ListTourViewModel : ViewModelBase
    {
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

        private object _myCollectionLock = new object();

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

        public AddTourCommand AddTourCommand { get; }
        public EditTourCommand EditTourCommand { get; }

        public ListTourViewModel(NavigationStore navigationStore)
        {
            this.NavigationStore = navigationStore;

            Tours = new ObservableCollection<Tour>();
            BindingOperations.EnableCollectionSynchronization(Tours, _myCollectionLock);

            TourManager tourManager = new TourManager();
            List<Tour> allTours = tourManager.GetTours();

            foreach (var tour in allTours)
            {
                Tours.Add(tour);
            }

            AddTourCommand = new AddTourCommand(navigationStore);
            EditTourCommand = new EditTourCommand(navigationStore);
        }

    }
}

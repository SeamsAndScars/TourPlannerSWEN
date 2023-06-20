using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.Views;

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
                OnPropertyChanged(nameof(tours));
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
                OnPropertyChanged(nameof(selectedTour));
            }
        }

        private TimeOnly _selectedTourTime;
        public TimeOnly SelectedTourTime
        {
            get { return _selectedTourTime; }
            set
            {
                _selectedTourTime = value;
                OnPropertyChanged(nameof(SelectedTourTime));
            }
        }

        public AddTourCommand AddTourCommand { get; }
        public EditTourCommand EditTourCommand { get; }

        public ListTourViewModel(NavigationStore navigationStore)
        {

            this.NavigationStore = navigationStore;

            Tours = new ObservableCollection<Tour>();

            // Create an instance of TourRepository
            TourRepository tourRepository = new TourRepository();

            // Retrieve all tours from the database
            List<Tour> allTours = tourRepository.GetTours();

            // Populate the Tours collection with the retrieved tours
            foreach (var tour in allTours)
            {
                Tours.Add(tour);
            }

            AddTourCommand = new AddTourCommand(navigationStore);
            EditTourCommand = new EditTourCommand(navigationStore);
        }



        private UserControl currentView;
        public UserControl CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

    }

}

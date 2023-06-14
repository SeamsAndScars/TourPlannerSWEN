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

        public Commands.AddTourCommand AddTourCommand { get; }

        public ListTourViewModel(NavigationStore navigationStore)
        {
            //CurrentView = new ListTourView();
            Tours = new ObservableCollection<Tour>();

            // Populate the Tours collection with sample data
            Tours.Add(new Tour("Tour1", "This is a very great description; 1", "Hier", "Dort", _TransportType.Bike));
            Tours.Add(new Tour("Tour2", "This is a very great description; 2", "Dort", "Hier", _TransportType.Hike));
            Tours.Add(new Tour("Tour3", "This is a very great description; 3", "Wien", "Vienna", _TransportType.Run));

            AddTourCommand = new Commands.AddTourCommand(navigationStore);
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

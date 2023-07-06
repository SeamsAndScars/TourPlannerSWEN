using System.Collections.Generic;
using System.Collections.ObjectModel;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.BL;
using System.Windows.Data;
using System;
using System.Windows;

namespace TourPlanner_Client.ViewModels
{
    public class ListTourViewModel : ViewModelBase
    {
        private TourManager tourManager;
        private ObservableCollection<Tour> tours;
        private NavigationStore navigationStore;
        private Tour selectedTour;
        private List<TourLog> tourLogs;

        public AddTourCommand AddTourCommand { get; }
        public EditTourCommand EditTourCommand { get; }
        public AddTourLogCommand AddTourLogCommand { get; }

        public List<TourLog> TourLogs
        {
            get { return tourLogs; }
            set
            {
                tourLogs = value;
                OnPropertyChanged(nameof(TourLogs));
            }
        }

        public ObservableCollection<Tour> Tours
        {
            get { return tours; }
            set
            {
                tours = value;
                OnPropertyChanged(nameof(Tours));
            }
        }

        public NavigationStore NavigationStore
        {
            get { return navigationStore; }
            set
            {
                navigationStore = value;
                OnPropertyChanged(nameof(NavigationStore));
            }
        }

        public Tour SelectedTour
        {
            get { return selectedTour; }
            set
            {
                selectedTour = value;
                LoadTourLogs(selectedTour);
                OnPropertyChanged(nameof(SelectedTour));
            }
        }

        private void LoadTourLogs(Tour tour)
        {
            if (tour != null)
            {
                List<TourLog> logs = tourManager.GetTourLogs(tour);
                TourLogs = new List<TourLog>(logs);
            }
            else
            {
                TourLogs = new List<TourLog>();
            }
        }


        public ListTourViewModel(NavigationStore navigationStore)
        {
            NavigationStore = navigationStore;

            tourManager = TourManager.Instance;
            tourManager.TourModified += TourManager_TourModified;
            LoadTours();

            AddTourCommand = new AddTourCommand(navigationStore);
            EditTourCommand = new EditTourCommand(navigationStore);
            AddTourLogCommand = new AddTourLogCommand(this,navigationStore, tourManager);
        }

        private void LoadTours()
        {
            List<Tour> tourList = tourManager.GetTours();
            Tours = new ObservableCollection<Tour>(tourList);
        }

        private void TourManager_TourModified(object sender, EventArgs e)
        {
            LoadTours();
        }

    }
}

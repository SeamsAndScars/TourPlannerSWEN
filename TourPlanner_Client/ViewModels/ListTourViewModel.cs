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

        public AddTourCommand AddTourCommand { get; }
        public EditTourCommand EditTourCommand { get; }
        public AddTourLogCommand AddTourLogCommand { get; }

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
                OnPropertyChanged(nameof(SelectedTour));
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
            AddTourLogCommand = new AddTourLogCommand(this,navigationStore);
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

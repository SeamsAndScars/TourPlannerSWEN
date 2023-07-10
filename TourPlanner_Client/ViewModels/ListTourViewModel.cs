using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.BL;
using System;
using System.Windows.Media;

namespace TourPlanner_Client.ViewModels
{
    public class ListTourViewModel : ViewModelBase
    {
        private TourManager tourManager;
        private ObservableCollection<Tour> tours;
        private NavigationStore navigationStore;
        private Tour selectedTour;
        private List<TourLog> tourLogs;
        private TourLog selectedTourLog;
        private string searchQuery;

        public string SearchQuery
        {
            get { return searchQuery; }
            set
            {
                searchQuery = value;
                FilterTours();
                OnPropertyChanged(nameof(SearchQuery));
            }
        }

        public int Popularity { get; set; }
        public int ChildFriendliness { get; set; }
        public string ChildFriendlinessLabel { get; set; }

        public AddTourCommand AddTourCommand { get; }
        public EditTourCommand EditTourCommand { get; }
        public AddTourLogCommand AddTourLogCommand { get; }

        private EditTourLogCommand editTourLogCommand;
        public GenerateTourLogReportCommand GenerateTourLogReport { get; }
        public GenerateTourSummaryCommand GenerateTourSummaryCommand { get; }
        public ExportTourCommand ExportTourCommand { get; }

        public List<TourLog> TourLogs
        {
            get { return tourLogs; }
            set
            {
                tourLogs = value;
                OnPropertyChanged(nameof(TourLogs));
                CalculateAttributes();
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
                CalculateAttributes();
            }
        }

        public TourLog SelectedTourLog
        {
            get { return selectedTourLog; }
            set
            {
                selectedTourLog = value;
                OnPropertyChanged(nameof(SelectedTourLog));
                InitializeEditTourLogCommand();
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

        public EditTourLogCommand EditTourLogCommand
        {
            get { return editTourLogCommand; }
            set
            {
                editTourLogCommand = value;
                OnPropertyChanged(nameof(EditTourLogCommand));
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
            AddTourLogCommand = new AddTourLogCommand(this, navigationStore, tourManager);

            InitializeEditTourLogCommand();
            GenerateTourLogReport = new GenerateTourLogReportCommand(this, tourManager);
            GenerateTourSummaryCommand = new GenerateTourSummaryCommand(this,tourManager);
            ExportTourCommand = new ExportTourCommand(tourManager);
        }

        private void LoadTours()
        {
            List<Tour> tourList = tourManager.GetTours();
            Tours = new ObservableCollection<Tour>(tourList);
            FilterTours();
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

        private void InitializeEditTourLogCommand()
        {
            if (SelectedTour != null && SelectedTourLog != null)
            {
                EditTourLogCommand = new EditTourLogCommand(navigationStore, SelectedTourLog);

            }
            else
            {
                EditTourLogCommand = null;
            }
        }

        private void CalculateAttributes()
        {
            if (SelectedTour is not null)
            {
                // Calculate popularity based on the number of logs
                Popularity = TourLogs.Count;

                // Calculate child-friendliness based on difficulty values, total times, and distance
                ChildFriendliness = CalculateChildFriendliness();

                // Update the child-friendliness string representation
                ChildFriendlinessLabel = ChildFriendlinessConverter.ConvertToString(ChildFriendliness); // Assuming ChildFriendliness is an integer
            }
            else
            {
                Popularity = 0;
                ChildFriendliness = 0;
                ChildFriendlinessLabel = string.Empty;
            }

            OnPropertyChanged(nameof(Popularity));
            OnPropertyChanged(nameof(ChildFriendlinessLabel));
        }

        public int CalculateChildFriendliness()
        {
            int totalDifficulty = 0;
            int totalTimeInHours = 0;
            double totalDistance = 0;
            double averageDifficulty = 0;

            // Calculate the sum of difficulty values and total distance from tour logs
            foreach (var tourLog in TourLogs)
            {
                totalDifficulty += (int)tourLog.Difficulty;
            }


            // Calculate the average difficulty
            if (TourLogs.Count > 0)
            {
                averageDifficulty = totalDifficulty / TourLogs.Count;
            }

            double selectedTourTimeInHours = SelectedTour.Estimate / 3600;
            double selectedTourDistance = SelectedTour.Distance;
            double childFriendliness = (averageDifficulty * 3 + selectedTourTimeInHours * 2 + selectedTourDistance / 4);
            
            // Calculate the child-friendliness based on the average difficulty, selected tour time, and distance
            


            return (int)(childFriendliness);
        }

        private void FilterTours()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                // Show all tours when the search query is empty
                Tours = new ObservableCollection<Tour>(tourManager.GetTours());
                //Searchbox.Background = (ImageBrush)FindResource("watermark");
            }
            else
            {
                // Filter tours based on the search query
                Tours = new ObservableCollection<Tour>(
                    tourManager.GetTours().Where(tour => tour.Name.ToLower().Contains(SearchQuery.ToLower()))
                );
            }
        }

        private void TourManager_TourModified(object sender, EventArgs e)
        {
            LoadTours();
            CalculateAttributes();
        }
    }
}

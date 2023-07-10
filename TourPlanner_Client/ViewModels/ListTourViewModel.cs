using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.BL;
using System;
using System.Windows.Media;
using TourPlanner_Client.Search;

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

 
        public AddTourCommand AddTourCommand { get; }
        public EditTourCommand EditTourCommand { get; }
        public AddTourLogCommand AddTourLogCommand { get; }

        private EditTourLogCommand editTourLogCommand;
        public GenerateTourLogReportCommand GenerateTourLogReport { get; }
        public GenerateTourSummaryCommand GenerateTourSummaryCommand { get; }
        public ExportTourCommand ExportTourCommand { get; }
        public ImportTourCommand ImportTourCommand { get; }


        private int popularity;
        public int Popularity
        {
            get { return selectedTour?.Popularity ?? popularity; }
            set
            {
                if (selectedTour != null)
                {
                    selectedTour.Popularity = value;
                    OnPropertyChanged(nameof(Popularity));
                }
                else
                {
                    popularity = value;
                }
            }
        }

        private int childFriendliness;
        public int ChildFriendliness
        {
            get { return childFriendliness; }
            set
            {
                childFriendliness = value;
                OnPropertyChanged(nameof(ChildFriendliness));
            }
        }

        private string childFriendlinessLabel;
        public string ChildFriendlinessLabel
        {
            get { return selectedTour?.ChildFriendlinessLabel ?? childFriendlinessLabel; }
            set
            {
                if (selectedTour != null)
                {
                    selectedTour.ChildFriendlinessLabel = value;
                    OnPropertyChanged(nameof(ChildFriendlinessLabel));
                }
                else
                {
                    childFriendlinessLabel = value;
                }
            }
        }


        public List<TourLog> TourLogs
        {
            get { return tourLogs; }
            set
            {
                tourLogs = value;
                OnPropertyChanged(nameof(TourLogs));
            }
        }

        public Tour SelectedTour
        {
            get { return selectedTour; }
            set
            {
                selectedTour = value;
                LoadTourLogs(selectedTour);
                CalculateAttributes(selectedTour); // Calculate attributes for the selected tour
                OnPropertyChanged(nameof(SelectedTour));
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
            ImportTourCommand = new ImportTourCommand(tourManager);
        }

        private void LoadTours()
        {
            List<Tour> tourList = tourManager.GetTours();
            Tours = new ObservableCollection<Tour>(tourList);

            // Load tour logs for each tour
            foreach (var tour in Tours)
            {
                LoadTourLogs(tour);
                CalculateAttributes(tour);
            }

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

        private void CalculateAttributes(Tour tour)
        {
            if (tour != null)
            {
                // Calculate popularity based on the number of logs specific to the tour
                tour.Popularity = TourLogs.Count(log => log.TourId == tour.Id);

                // Calculate child-friendliness based on difficulty values, total times, and distance
                tour.ChildFriendliness = CalculateChildFriendliness(tour);

                // Update the child-friendliness string representation
                tour.ChildFriendlinessLabel = ChildFriendlinessConverter.ConvertToString(tour.ChildFriendliness);
            }
            else
            {
                // Reset the attributes for the selected tour
                if (selectedTour != null)
                {
                    selectedTour.Popularity = 0;
                    selectedTour.ChildFriendliness = 0;
                    selectedTour.ChildFriendlinessLabel = string.Empty;
                }
            }
        }




        public int CalculateChildFriendliness(Tour tour)
        {
            int totalDifficulty = 0;
            double averageDifficulty = 0;

            // Calculate the sum of difficulty values from tour logs of the specific tour
            foreach (var tourLog in TourLogs.Where(log => log.TourId == tour.Id))
            {
                totalDifficulty += (int)tourLog.Difficulty;
            }

            // Calculate the average difficulty
            int tourLogsCount = TourLogs.Count(log => log.TourId == tour.Id);
            if (tourLogsCount > 0)
            {
                averageDifficulty = totalDifficulty / tourLogsCount;
            }

            double selectedTourTimeInHours = tour.Estimate / 3600;
            double selectedTourDistance = tour.Distance;
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
            }
            else
            {
                // Filter tours based on the search query
                Tours = new ObservableCollection<Tour>(
                    tourManager.GetTours().Where(tour =>
                        tour.ContainsSearchQuery(SearchQuery) ||
                        tour.TourLogs.Any(log => log.ContainsSearchQuery(SearchQuery))
                    )
                );
            }
        }


        private void TourManager_TourModified(object sender, EventArgs e)
        {
            LoadTours();
        }
    }
}

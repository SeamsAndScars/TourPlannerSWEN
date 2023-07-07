using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.Validation;


namespace TourPlanner_Client.ViewModels
{
    public class AddTourLogViewModel : ViewModelBase
    {
        private TourManager tourManager;
        private TourLog tourLog;
        private NavigationStore navigationStore;
        private Tour tour;
        private Rating _selectedRating;
        private Difficulty _selectedDifficulty;
        private string _Comment = string.Empty;
        private string _Time = string.Empty;
        private Tour selectedTour;
        private DateTime? _selectedDate;
        public DateTime NonNullableSelectedDate => SelectedDate ?? DateTime.Today;

        public List<Difficulty> DifficultyTypes { get; } = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
        public List<Rating> RatingTypes { get; } = Enum.GetValues(typeof(Rating)).Cast<Rating>().ToList();
        public CancelTourCommand CancelTourCommand { get; }
        public SubmitTourLogCommand SubmitTourLogCommand { get; }

        private ValidateTotalTime validateTotalTime;


        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                if (value == null) { return; }
                _Comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }


        public string Time
        {
            get { return _Time; }
            set
            {
                if (value == null) { return; }

                if (validateTotalTime.ValidateTime(value))
                {
                    _Time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }


        public DateTime? SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        public Difficulty SelectedDifficulty
        {
            get { return _selectedDifficulty; }
            set
            {
                _selectedDifficulty = value;
                OnPropertyChanged(nameof(SelectedDifficulty));
            }
        }
        
        public Rating SelectedRating
        {
            get { return _selectedRating; }
            set
            {
                _selectedRating = value;
                OnPropertyChanged(nameof(SelectedRating));
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

        public AddTourLogViewModel(NavigationStore navigationStore, Tour selectedTour, List<TourLog> tourLogs)
        {
            this.navigationStore = navigationStore;
            tour = selectedTour;
            CancelTourCommand = new CancelTourCommand(navigationStore);
            SubmitTourLogCommand = new SubmitTourLogCommand(navigationStore, this, tour);
            validateTotalTime = new ValidateTotalTime();
            //MessageBox.Show("Comment:" + Comment + "\nDifficulty:" + _selectedDifficulty.ToString() + "\nSelected Date:" + SelectedDate.ToString() + "\nType of Date:" + SelectedDate.GetType().ToString());
            //tourLog = new TourLog(tour.Id, DateOnly.MaxValue, Comment, _selectedDifficulty, TimeOnly.MaxValue, _selectedRating);
        }
    }
}

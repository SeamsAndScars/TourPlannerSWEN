using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TourPlanner_Client.BL;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.Validation;

namespace TourPlanner_Client.ViewModels
{
    public class EditTourLogViewModel : ViewModelBase
    {
        private TourLog tourLog;
        private NavigationStore navigationStore;
        private TourManager tourManager;
        private DateTime selectedDate;
        private string comment;
        private Difficulty selectedDifficulty;
        private string time;
        private Rating selectedRating;
        public CancelTourCommand CancelTourCommand { get; }
        private ValidateTotalTime validateTotalTime;
        public List<Difficulty> DifficultyTypes { get; } = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
        public List<Rating> RatingTypes { get; } = Enum.GetValues(typeof(Rating)).Cast<Rating>().ToList();

        public Guid Id
        {
            get { return tourLog.Id; }
            set
            {
                tourLog.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        public Difficulty SelectedDifficulty
        {
            get { return selectedDifficulty; }
            set
            {
                selectedDifficulty = value;
                OnPropertyChanged(nameof(SelectedDifficulty));
            }
        }

        public string Time
        {
            get { return time; }
            set
            {
                if (value == null) { return; }

                var validateTotalTime = new ValidateTotalTime();
                if (validateTotalTime.ValidateTime(value))
                {
                    time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }

        public Rating SelectedRating
        {
            get { return selectedRating; }
            set
            {
                selectedRating = value;
                OnPropertyChanged(nameof(SelectedRating));
            }
        }

        public SubmitChangeCommand SubmitChangeCommand { get; }

        public ICommand DeleteTourCommand => new DeleteTourLogCommand(this, navigationStore);

        public EditTourLogViewModel(NavigationStore navigationStore, TourLog selectedTourLog, TourLog tourLog)
        {
            this.navigationStore = navigationStore;
            this.tourLog = tourLog;
            tourManager = TourManager.Instance;

            // Initialize the properties with the existing values
            SelectedDate = tourLog.Date;
            Comment = tourLog.Comment;
            SelectedDifficulty = tourLog.Difficulty;
            Time = tourLog.Time;
            SelectedRating = tourLog.Rating;
            CancelTourCommand = new CancelTourCommand(navigationStore);
            SubmitChangeCommand = new SubmitChangeCommand(this, navigationStore);
            validateTotalTime = new ValidateTotalTime();
        }
    }
}

using System;
using System.Windows.Input;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;

namespace TourPlanner_Client.ViewModels
{
    public class EditTourViewModel : ViewModelBase
    {
        private Tour tour;
        private readonly NavigationStore _navigationStore;

        public string Name
        {
            get { return tour.Name; }
            set
            {
                tour.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get { return tour.Description; }
            set
            {
                tour.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Source
        {
            get { return tour.Source; }
            set
            {
                tour.Source = value;
                OnPropertyChanged(nameof(Source));
            }
        }

        public string Destination
        {
            get { return tour.Destination; }
            set
            {
                tour.Destination = value;
                OnPropertyChanged(nameof(Destination));
            }
        }

        public _TransportType TransportType
        {
            get { return tour.Ttype; }
            set
            {
                tour.Ttype = value;
                OnPropertyChanged(nameof(TransportType));
            }
        }

        public ICommand SubmitChangeCommand { get; }
        public ICommand DeleteTourCommand { get; }

        public EditTourViewModel(NavigationStore navigationStore, Tour selectedTour)
        {
            _navigationStore = navigationStore;
            tour = selectedTour;
            SubmitChangeCommand = new SubmitChangeCommand(this);
            DeleteTourCommand = new DeleteTourCommand(this);
        }

        // Additional logic for SubmitChangeCommand and DeleteTourCommand
    }
}

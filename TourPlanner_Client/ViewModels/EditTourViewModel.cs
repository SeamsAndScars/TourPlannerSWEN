using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
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

        public Guid Id { get; set; } // Add Id property

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

        //Displays the different Values of the TransportType enumerable
        private _TransportType _selectedTransportType;
        public _TransportType SelectedTransportType
        {
            get { return _selectedTransportType; }
            set
            {
                _selectedTransportType = value;
                OnPropertyChanged(nameof(SelectedTransportType));
            }
        }

        public List<_TransportType> TransportTypes { get; } = Enum.GetValues(typeof(_TransportType)).Cast<_TransportType>().ToList();

        //public ICommand SubmitChangeCommand { get; }
        public ICommand SubmitChangeCommand => new SubmitChangeCommand(this);
        public ICommand DeleteTourCommand { get; }

        public ICommand EditTourCommand { get; }

        public CancelTourCommand CancelTourCommand { get; }

        public EditTourViewModel(NavigationStore navigationStore, Tour selectedTour)
        {
            _navigationStore = navigationStore;
            tour = selectedTour;
            Id = selectedTour.Id;
            SelectedTransportType = tour.Ttype;
            //SubmitChangeCommand = new SubmitChangeCommand(this);
            DeleteTourCommand = new DeleteTourCommand(this);
            CancelTourCommand = new CancelTourCommand(navigationStore);
        }

        // Additional logic for SubmitChangeCommand and DeleteTourCommand

        
    }
}

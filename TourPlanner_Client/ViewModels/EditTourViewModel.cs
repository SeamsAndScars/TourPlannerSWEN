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
        private TransportType _selectedTransportType;

        //GUID used for storing and accessing Tours in the DB
        public Guid Id { get; set; }
        public List<TransportType> TransportTypes { get; } = Enum.GetValues(typeof(TransportType)).Cast<TransportType>().ToList();
        public ICommand SubmitChangeCommand => new SubmitChangeCommand(this, _navigationStore);
        public ICommand DeleteTourCommand { get; }
        public ICommand EditTourCommand { get; }
        public CancelTourCommand CancelTourCommand { get; }

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
        public TransportType SelectedTransportType
        {
            get { return _selectedTransportType; }
            set
            {
                _selectedTransportType = value;
                OnPropertyChanged(nameof(SelectedTransportType));
            }
        }

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

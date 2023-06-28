using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Models;
using TourPlanner_Client.ViewModels;
using TourPlanner_Client.Stores;

namespace TourPlanner_Client.ViewModels
{
    public class AddTourViewModel : ViewModelBase
    {
       
        private string _Name = string.Empty;
        private string _Description = string.Empty;
        private string _Source = string.Empty;
        private string _Destination = string.Empty;
        private string newTourName;
        private _TransportType _selectedTransportType;
        private ObservableCollection<Tour> tours;

        public ICommand AddTourCommand { get; }
        public SubmitTourCommand SubmitTourCommand { get; }
        public CancelTourCommand CancelTourCommand { get; }
        public IEnumerable<_TransportType> TransportTypes => Enum.GetValues(typeof(_TransportType)).Cast<_TransportType>();

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (value == null) { return; }
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (value == null) { return; }
                _Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string Source
        {
            get
            {
                return _Source;
            }
            set
            {
                if (value == null) { return; }
                _Source = value;
                OnPropertyChanged(nameof(Source));
            }
        }
        public string Destination
        {
            get
            {
                return _Destination;
            }
            set
            {
                if (value == null) { return; }
                _Destination = value;
                OnPropertyChanged(nameof(Destination));
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

        public string NewTourName
        {
            get { return newTourName; }
            set
            {
                newTourName = value;
                OnPropertyChanged(nameof(NewTourName));
            }
        }

        // Other properties for capturing the new tour details

        public AddTourViewModel(NavigationStore navigationStore)
        {
            CancelTourCommand = new CancelTourCommand(navigationStore);
            SubmitTourCommand = new SubmitTourCommand(navigationStore, this);
        }

        //Displays the different Values of the TransportType enumerable
        public _TransportType SelectedTransportType
        {
            get { return _selectedTransportType; }
            set
            {
                _selectedTransportType = value;
                OnPropertyChanged(nameof(SelectedTransportType));
            }
        }

    }

}

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
        //public List<TourLogs>? TourLogs { get; set; }
        private string _Description = string.Empty;
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
        private string _Source = string.Empty;
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
        private string _Destination = string.Empty;
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

        private ObservableCollection<Tour> tours;
        public ObservableCollection<Tour> Tours
        {
            get { return tours; }
            set
            {
                tours = value;
                OnPropertyChanged(nameof(Tours));
            }
        }

        private string newTourName;
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


        
        public ICommand SubmitTourCommand => new SubmitTourCommand(this);
        public ICommand AddTourCommand { get; }

        public Commands.CancelTourCommand CancelTourCommand{ get; }

        public AddTourViewModel(NavigationStore navigationStore)
        {
            CancelTourCommand = new Commands.CancelTourCommand(navigationStore);
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

        public IEnumerable<_TransportType> TransportTypes => Enum.GetValues(typeof(_TransportType)).Cast<_TransportType>();
    }

}

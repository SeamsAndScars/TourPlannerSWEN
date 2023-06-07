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
        //public _TransportType Ttype { get; set; }
        //public float Distance { get; set; }
        //public DateTime Estimate { get; set; }
        //public object Image { get; set; }

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

        /*
        public AddTourViewModel(ObservableCollection<Tour> existingTours)
        {
            Tours = existingTours;

            // Other initialization code...

            AddTourCommand = new AddTourCommand(AddTour);
        }

        public AddTourViewModel()
        {
            AddTourCommand = new AddTourCommand();
        }

            private void AddTour()
        {
            // Logic to add a new tour to the collection
            Tours.Add(new Tour("NewTour", "NewDescription", "NeuerOrt", "NeuesZiel", 3));

            //// Clear the input fields or reset the properties
            //NewTourName = string.Empty;
            //NewTourDescription = string.Empty;
            //NewTourSource = string.Empty;
            //NewTourDestination = string.Empty;
            //NewTourType = 0;
        }
        */

        // Rest of the class implementation
    }

}

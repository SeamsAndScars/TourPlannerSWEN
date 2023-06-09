using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TourPlanner_Client.ViewModels
{
    internal class SearchViewModel : ViewModelBase
    {
        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get { return _searchCommand; }
            set
            {
                _searchCommand = value;
                OnPropertyChanged(nameof(SearchCommand));
            }
        }

        // Constructor
        public SearchViewModel()
        {
            //SearchCommand = new RelayCommand(Search);
        }

        private void Search(object parameter)
        {
            // Handle search functionality
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner_Client.Stores;

namespace TourPlanner_Client.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore) 
        { 
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }  

        private void OnCurrentViewModelChanged() 
        { 
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}

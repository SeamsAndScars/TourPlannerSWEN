using System;
using TourPlanner_Client.BL;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Stores
{
    public class NavigationStore 
    {
        private ViewModelBase _currentViewModel;
        private static NavigationStore instance;
        public static NavigationStore Instance
        {
            get
            {
                if (instance == null)
                    instance = new NavigationStore();

                return instance;
            }
        }
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;
    }
}

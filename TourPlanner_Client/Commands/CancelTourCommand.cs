using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class CancelTourCommand:CommandBase
    {
        public ListTourViewModel ViewModel { get; set; }
        private readonly NavigationStore _navigationStore;

        public CancelTourCommand(ListTourViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public CancelTourCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {

            _navigationStore.CurrentViewModel = new ListTourViewModel(_navigationStore);
        }
    }
}

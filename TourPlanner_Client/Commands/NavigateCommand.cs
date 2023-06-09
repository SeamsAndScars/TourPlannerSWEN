using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class NavigateCommand : CommandBase
    {
        private UserControl viewModel;
        private readonly NavigationStore _navigationStore;

        public NavigateCommand(NavigationStore navigationStore)
        {
            _navigationStore= navigationStore; 
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new AddTourViewModel(_navigationStore);
        }

    }
}

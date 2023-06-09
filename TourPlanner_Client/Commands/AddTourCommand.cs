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
    public class AddTourCommand : CommandBase
    {
        public AddTourCommand(AddTourViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public AddTourViewModel ViewModel { get; set; }
        private readonly NavigationStore _navigationStore;

        public AddTourCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        } 

        public override void Execute(object parameter)
        {

           _navigationStore.CurrentViewModel = new AddTourViewModel(_navigationStore);
            if (ViewModel == null)
            {
                return;
            }
            MessageBox.Show(ViewModel.Description);
         
        }
    }
}

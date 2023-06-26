using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class SubmitTourCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public AddTourViewModel ViewModel { get; set; }
        

        public SubmitTourCommand(NavigationStore navigationStore, AddTourViewModel viewModel)
        {
            _navigationStore = navigationStore;
            ViewModel = viewModel;
        }

       public SubmitTourCommand(AddTourViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        //when pressing the submit button, a new tour gets added into the db
        public override void Execute(object parameter)
        {
            TourManager tourManager = new TourManager();
            tourManager.AddTour(ViewModel);

            //MessageBox.Show("Tour added!");
            _navigationStore.CurrentViewModel = new ListTourViewModel(_navigationStore);
        }
    }
}

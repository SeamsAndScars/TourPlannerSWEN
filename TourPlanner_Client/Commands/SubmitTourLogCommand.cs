using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.Stores;
using TourPlanner_Client.Models;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class SubmitTourLogCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private AddTourLogViewModel ViewModel { get; set; }
        private Tour selectedtour {get; set;}
        private TourLog tourLog { get; set;}


        public SubmitTourLogCommand(NavigationStore navigationStore, AddTourLogViewModel viewModel,Tour tour)
        {
            _navigationStore = navigationStore;
            ViewModel = viewModel;
            selectedtour = tour;
        }

        public SubmitTourLogCommand(AddTourLogViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        //when pressing the submit button, a new tour gets added into the db
        public override void Execute(object parameter)
        {
            if ( ViewModel.SelectedDate is null)
            {
                //TODO error handling
                MessageBox.Show("Please select a Date!");
                return;
            }
            TourManager tourManager = TourManager.Instance;
            tourManager.AddTourLog(selectedtour, ViewModel);

            //MessageBox.Show("Comment:" + ViewModel.Comment + "\nDifficulty:" + ViewModel.SelectedDifficulty.ToString() + "\nSelected Date:" + ViewModel.SelectedDate.ToString());
            

            _navigationStore.CurrentViewModel = new ListTourViewModel(_navigationStore);
        }
    }
}

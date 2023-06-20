using System;
using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.Models;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class SubmitChangeCommand : CommandBase
    {
        public EditTourViewModel ViewModel { get; set; }

        public SubmitChangeCommand(EditTourViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            // Update the tour in the database
            TourManager tourManager = new TourManager();
            tourManager.UpdateTour(ViewModel);

            MessageBox.Show("Changes submitted!");
        }
    }
}
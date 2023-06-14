using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.BL.Tour;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class SubmitTourCommand : CommandBase
    {
        public AddTourViewModel ViewModel { get; set; } 

        public SubmitTourCommand(AddTourViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        //when pressing the submit button, a new tour gets added into the db
        public override void Execute(object parameter)
        {
            AddTour addTour = new AddTour();
            addTour.Add(ViewModel);

            MessageBox.Show("Tour added!");
        }
    }
}

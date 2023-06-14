using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public override void Execute(object parameter)
        {
            MessageBox.Show("SubmitTourCommand executed!");


        }
    }
}

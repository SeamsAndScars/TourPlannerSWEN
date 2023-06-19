using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class SubmitChangeCommand : CommandBase
    {
        private readonly EditTourViewModel _viewModel;

        public SubmitChangeCommand(EditTourViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            // Add logic to save the changes to the tour

            MessageBox.Show("Changes submitted!");
        }
    }
}

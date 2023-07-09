using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.BL.Models;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class GenerateTourSummaryCommand : CommandBase
    {
        private readonly ListTourViewModel _viewModel;
        private readonly TourManager _tourManager;

        public GenerateTourSummaryCommand(ListTourViewModel viewModel, TourManager tourManager)
        {
            _viewModel = viewModel;
            _tourManager = tourManager;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.Tours != null)
            {
                // Add logic to generate a report

                if(_viewModel.Tours.Count == 0)
                {
                    MessageBox.Show("There was no tour added yet.\n You need to add a tour before generating a report!");
                    return;
                }

                //MessageBox.Show("WIP\nGenerating Report: \n" + tls.Count);
                TourReportGenerator.GenerateSummaryReport(_tourManager);
            }
            else
            {
                MessageBox.Show("Invalid tour selected.");
            }

        }

    }
}

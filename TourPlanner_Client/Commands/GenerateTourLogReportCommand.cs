using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.BL.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.Commands
{
    public class GenerateTourLogReportCommand : CommandBase
    {
        private readonly ListTourViewModel _viewModel;
        private readonly TourManager _tourManager;

        public GenerateTourLogReportCommand(ListTourViewModel viewModel,TourManager tourmanager)
        {
            _viewModel = viewModel;
            _tourManager = tourmanager;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.SelectedTour != null)
            {
                // Add logic to generate a report
                
                _viewModel.TourLogs = _tourManager.GetTourLogs(_viewModel.SelectedTour);
                //MessageBox.Show("WIP\nGenerating Report: \n" + tls.Count);
                TourReportGenerator.GenerateReport(_viewModel.SelectedTour);
            }
            else
            {
                MessageBox.Show("Invalid tour selected.");
            }
            
        }

    }
}

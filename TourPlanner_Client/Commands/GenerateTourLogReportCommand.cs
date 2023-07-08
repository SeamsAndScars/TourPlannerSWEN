using System.Windows;
using TourPlanner_Client.BL.Models;
using TourPlanner_Client.BL;
using TourPlanner_Client.Commands;
using TourPlanner_Client.ViewModels;

public class GenerateTourLogReportCommand : CommandBase
{
    private readonly ListTourViewModel _viewModel;
    private readonly TourManager _tourManager;

    public GenerateTourLogReportCommand(ListTourViewModel viewModel, TourManager tourManager)
    {
        _viewModel = viewModel;
        _tourManager = tourManager;
    }

    public override void Execute(object parameter)
    {
        if (_viewModel.SelectedTour != null)
        {
            // Add logic to generate a report
            _viewModel.TourLogs = _tourManager.GetTourLogs(_viewModel.SelectedTour);

            int popularity = _viewModel.Popularity;
            string childFriendlinessLabel = _viewModel.ChildFriendlinessLabel;

            TourReportGenerator.GenerateReport(_viewModel.SelectedTour, popularity, childFriendlinessLabel);
        }
        else
        {
            MessageBox.Show("Invalid tour selected.");
        }
    }
}

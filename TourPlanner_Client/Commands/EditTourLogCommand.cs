using System.Windows;
using TourPlanner_Client.Models;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;
using TourPlanner_Client.Views;

namespace TourPlanner_Client.Commands
{
    public class EditTourLogCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public TourLog SelectedTourLog { get; set; }

        public EditTourLogCommand(NavigationStore navigationStore, TourLog selectedTourLog)
        {
            _navigationStore = navigationStore;
            SelectedTourLog = selectedTourLog;
        }

        public override void Execute(object parameter)
        {
            if (this.SelectedTourLog != null)
            {
                _navigationStore.CurrentViewModel = new EditTourLogViewModel(_navigationStore, SelectedTourLog, SelectedTourLog);
            }
            else
            {
                MessageBox.Show("Invalid tour log selected.");
            }
        }
    }
}

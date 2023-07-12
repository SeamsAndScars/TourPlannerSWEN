using System.Windows.Controls;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Stores;

namespace TourPlanner_Client.Views
{
    public partial class CancelButton : UserControl
    {
        public CancelTourCommand CancelTourCommand { get; }

        public CancelButton()
        {
            InitializeComponent();
            CancelTourCommand = new CancelTourCommand(NavigationStore.Instance);
        }
    }
}

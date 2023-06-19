using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourPlanner_Client.Models;
using TourPlanner_Client.ViewModels;
using TourPlanner_Client.Commands;
using TourPlanner_Client.Stores;

namespace TourPlanner_Client.Views
{
    /// <summary>
    /// Interaction logic for ListTourView.xaml
    /// </summary>
    public partial class ListTourView : UserControl
    {
        public ListTourView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Handle the button click event here
        }

        //private readonly NavigationStore _navigationStore;

        private void ListBoxItem_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBoxItem listBoxItem && listBoxItem.DataContext is Tour selectedTour)
            {
                var viewModel = (ListTourViewModel)DataContext;
                var navigationStore = (NavigationStore)viewModel.NavigationStore;

                InitializeComponent();
                // Update the navigation store to navigate to the EditTourView
                navigationStore.CurrentViewModel = new EditTourViewModel(navigationStore, selectedTour);
            }
        }
    }
}

﻿    using System;
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
using System.Windows.Controls.Primitives;

    namespace TourPlanner_Client.Views
    {
        /// <summary>
        /// Interaction logic for ListTourView.xaml
        /// </summary>
        public partial class ListTourView : UserControl
        {
            private NavigationStore navigationStore = NavigationStore.Instance;
            
            public ListTourView()
            {
                InitializeComponent();

            }
            
            private void ListBoxItem_DoubleClick(object sender, MouseButtonEventArgs e)
            {
            
                if (sender is ListBoxItem listBoxItem && listBoxItem.DataContext is Tour selectedTour)
                {
                    navigationStore = ((ListTourViewModel)DataContext).NavigationStore;
                    navigationStore.CurrentViewModel = new EditTourViewModel(navigationStore, selectedTour);
               
                }
            }

        private void OnCurrentViewModelChanged()
            {
                ViewModelBase currentViewModel = navigationStore.CurrentViewModel;

            }


    }
    }

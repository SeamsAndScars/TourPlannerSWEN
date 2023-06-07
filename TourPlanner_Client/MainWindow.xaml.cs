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
using TourPlanner_Client.ViewModels;
using TourPlanner_Client.Converters;

namespace TourPlanner_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //List<string> items = new List<string>()
            //{
            //    "Item 1",
            //    "Item 2",
            //    "Item 3",
            //    "Item 4",
            //    "Item 5",
            //    "Item 6",
            //    "Item 7",
            //    "Item 8",
            //    "Item 9",
            //    "Item 10"
            //};

            //myListBox.ItemsSource = items;
            //DataContext = new ListTourViewModel(_nav);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Handle the button click event here
        }
    }
}

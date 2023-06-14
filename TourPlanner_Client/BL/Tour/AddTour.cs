using System;
using System.Collections.Generic;
using System.Text;
using TourPlanner_Client.DAL.Database;
using TourPlanner_Client.Models;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.BL.Tour
{
    public class AddTour
    {
        public void Add(AddTourViewModel tourViewModel)
        {
            TourPlanner_Client.Models.Tour newTour = new TourPlanner_Client.Models.Tour(
                tourViewModel.Name,
                tourViewModel.Description,
                tourViewModel.Source,
                tourViewModel.Destination,
                tourViewModel.SelectedTransportType
            );

            // You can perform additional logic or validations here if needed

            // Now you have the new tour object, and you can proceed with storing it or performing other operations

            // For example, you can use your DAL (Data Access Layer) to add the tour to the database
            TourRepository tourRepository = new TourRepository();
            tourRepository.Add(newTour);
        }
    }
}
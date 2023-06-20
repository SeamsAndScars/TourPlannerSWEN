using System;
using System.Collections.Generic;
using TourPlanner_Client.DAL;
using TourPlanner_Client.Models;
using TourPlanner_Client.ViewModels;

namespace TourPlanner_Client.BL
{
    public class TourManager
    {
        private readonly TourRepository tourRepository;

        public TourManager()
        {
            tourRepository = new TourRepository();
        }

        public List<Tour> GetTours()
        {
            return tourRepository.GetTours();
        }


        //should be named "CreateTour" but whatever
        public void AddTour(AddTourViewModel tourViewModel)
        {
            Tour newTour = new Tour(
                tourViewModel.Name,
                tourViewModel.Description,
                tourViewModel.Source,
                tourViewModel.Destination,
                tourViewModel.SelectedTransportType
            );

           
            tourRepository.CreateTour(newTour);
        }

        // Other methods for CRUD operations, e.g., UpdateTour, DeleteTour

        public void UpdateTour(EditTourViewModel tourViewModel)
        {
            Tour updatedTour = new Tour(
                tourViewModel.Name,
                tourViewModel.Description,
                tourViewModel.Source,
                tourViewModel.Destination,
                tourViewModel.SelectedTransportType
            );

            // Set the ID of the updated tour to the ID of the existing tour
            updatedTour.Id = tourViewModel.Id;

            tourRepository.UpdateTour(updatedTour);
        }
    }
}

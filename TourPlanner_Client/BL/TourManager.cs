using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TourPlanner_Client.DAL;
using TourPlanner_Client.Models;
using TourPlanner_Client.ViewModels;
using System.IO;
using TourPlanner_Client.APIs;


namespace TourPlanner_Client.BL
{
    public class TourManager
    {
        private readonly TourRepository tourRepository;
        private readonly MapQuestService mapQuestService;

        public TourManager()
        {
            tourRepository = new TourRepository();
            mapQuestService = new MapQuestService("lejXayouqJddAgi89X1OcCGzJ2IjsBP8");
        }

        public List<Tour> GetTours()
        {
            List<Tour> tours = tourRepository.GetTours();
            foreach (Tour tour in tours)
            {
                // Convert distance from miles to kilometers
                tour.Distance = (float)Math.Round(tour.Distance * 1.60934f, 0);
            }
            return tours;
        }

        public async Task AddTour(AddTourViewModel tourViewModel)
        {
            Tour newTour = new Tour(
                tourViewModel.Name,
                tourViewModel.Description,
                tourViewModel.Source,
                tourViewModel.Destination,
                tourViewModel.SelectedTransportType
            );

            RouteInfo routeInfo = await mapQuestService.GetRouteInfo(tourViewModel.Source, tourViewModel.Destination);
            if (routeInfo != null)
            {
                // Set the properties of the new tour
                newTour.Distance = routeInfo.Distance;
                newTour.Estimate = routeInfo.Estimate;
                newTour.ImageFileName = routeInfo.ImageFileName;

                tourRepository.CreateTour(newTour);
            }
            else
            {
                // Handle the error case
                // TODO: Handle the error case
            }
        }

        //public void UpdateTour(EditTourViewModel tourViewModel)
        //{
        //    Tour updatedTour = new Tour(
        //        tourViewModel.Name,
        //        tourViewModel.Description,
        //        tourViewModel.Source,
        //        tourViewModel.Destination,
        //        tourViewModel.SelectedTransportType
        //    );

        //    // Set the ID of the updated tour to the ID of the existing tour
        //    updatedTour.Id = tourViewModel.Id;

        //    tourRepository.UpdateTour(updatedTour);
        //}

        public async Task UpdateTour(EditTourViewModel tourViewModel)
        {
            Tour existingTour = tourRepository.GetTour(tourViewModel.Id);
            if (existingTour == null)
            {
                // Handle the error case when the tour does not exist
                // TODO: Handle the error case
                return;
            }

            if (existingTour.Source != tourViewModel.Source || existingTour.Destination != tourViewModel.Destination)
            {
                // The source or destination has changed, generate a new picture, distance, and estimate

                RouteInfo routeInfo = await mapQuestService.GetRouteInfo(tourViewModel.Source, tourViewModel.Destination);
                if (routeInfo != null)
                {
                    // Set the properties of the updated tour
                    existingTour.Distance = routeInfo.Distance;
                    existingTour.Estimate = routeInfo.Estimate;
                    existingTour.ImageFileName = routeInfo.ImageFileName;

                    // Update the tour in the repository
                    tourRepository.UpdateTour(existingTour);
                }
                else
                {
                    // Handle the error case
                    // TODO: Handle the error case
                    return;
                }
            }

            // Update other properties of the tour
            existingTour.Name = tourViewModel.Name;
            existingTour.Description = tourViewModel.Description;
            existingTour.Ttype = tourViewModel.SelectedTransportType;
            existingTour.Source = tourViewModel.Source;
            existingTour.Destination = tourViewModel.Destination;

            // Update the tour in the repository
            tourRepository.UpdateTour(existingTour);
        }
    }
}

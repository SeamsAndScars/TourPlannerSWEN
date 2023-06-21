using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TourPlanner_Client.DAL;
using TourPlanner_Client.Models;
using TourPlanner_Client.ViewModels;
using System.IO;


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
        public async Task AddTour(AddTourViewModel tourViewModel)
        {
            Tour newTour = new Tour(
                tourViewModel.Name,
                tourViewModel.Description,
                tourViewModel.Source,
                tourViewModel.Destination,
                tourViewModel.SelectedTransportType
            );

            // Make a request to the MapQuest Directions API to retrieve the route information
            string directionsUrl = $"https://www.mapquestapi.com/directions/v2/route?key=lejXayouqJddAgi89X1OcCGzJ2IjsBP8&from={Uri.EscapeDataString(tourViewModel.Source)}&to={Uri.EscapeDataString(tourViewModel.Destination)}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(directionsUrl);
                if (response.IsSuccessStatusCode)
                {
                    string directionsJson = await response.Content.ReadAsStringAsync();
                    dynamic directionsData = JsonConvert.DeserializeObject(directionsJson);

                    // Extract the distance and time from the response
                    float distance = directionsData.route.distance;
                    int seconds = directionsData.route.time;

                    // Make a request to the MapQuest Static Map API to retrieve the map image
                    string staticMapUrl = $"https://www.mapquestapi.com/staticmap/v5/map?key=lejXayouqJddAgi89X1OcCGzJ2IjsBP8&center={Uri.EscapeDataString(tourViewModel.Source)}&locations={Uri.EscapeDataString(tourViewModel.Destination)}";

                    // Send the request and retrieve the image data
                    byte[] imageData = await client.GetByteArrayAsync(staticMapUrl);

                    //Save image locally
                    string imageFileName = $"{Guid.NewGuid()}.png";
                    string imagePath = Path.Combine("..","..","..","Images", imageFileName);
                    

                    // Set the properties of the new tour
                    newTour.Distance = distance;
                    newTour.Estimate = DateTime.UtcNow.AddSeconds(seconds);
                    newTour.ImageFileName = imageFileName;


                    tourRepository.CreateTour(newTour);
                    File.WriteAllBytes(imagePath, imageData);
                }
                else
                {
                    // Handle the error response
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    // TODO: Handle the error case
                }
            }


            //tourRepository.CreateTour(newTour);
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

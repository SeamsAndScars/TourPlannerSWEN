using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TourPlanner_Client.DAL;
using TourPlanner_Client.Models;
using TourPlanner_Client.ViewModels;
using System.IO;

namespace TourPlanner_Client.APIs
{
    public class MapQuestService
    {
        private readonly string apiKey;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MapQuestService(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<RouteInfo> GetRouteInfo(string source, string destination)
        {
            string directionsUrl = $"https://www.mapquestapi.com/directions/v2/route?key={apiKey}&from={Uri.EscapeDataString(source)}&to={Uri.EscapeDataString(destination)}";

            using (HttpClient client = new HttpClient())
            {
                log.Info("Sending MapQuest API request.");
                HttpResponseMessage response = await client.GetAsync(directionsUrl);
                if (response.IsSuccessStatusCode)
                {
                    string directionsJson = await response.Content.ReadAsStringAsync();
                    dynamic directionsData = JsonConvert.DeserializeObject(directionsJson);

                    float distance = directionsData.route.distance;
                    int seconds = directionsData.route.time;

                    // Make a request to the MapQuest Static Map API to retrieve the map image
                    string staticMapUrl = GetStaticMapUrl(source, destination);
                    response = await client.GetAsync(staticMapUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        byte[] imageData = await response.Content.ReadAsByteArrayAsync();

                        string target = Path.Combine(Directory.GetCurrentDirectory() , "Images");
                        if (!Directory.Exists(target))
                        {
                            Directory.CreateDirectory(target);
                        }

                        // Save image locally
                        string imageFileName = $"{Guid.NewGuid()}.png";
                        string imagePath = Path.Combine(target, imageFileName);
                        File.WriteAllBytes(imagePath, imageData);

                        int estimate = seconds;

                        //convert to km
                        float distanceInKilometers = (int)Math.Round(distance * 1.60934, MidpointRounding.AwayFromZero);

                        return new RouteInfo(distanceInKilometers, estimate, imageFileName);
                    }
                    else
                    {
                        // Handle the error response from the Static Map API
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        log.Error("Error Code received from the MapQuest API.");
                        // TODO: Handle the error case
                    }
                }
                else
                {
                    // Handle the error response from the Directions API
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    log.Error("Error Code received from the MapQuest API.");
                    // TODO: Handle the error case
                }
            }

            return null;
        }

        public string GetStaticMapUrl(string source, string destination)
        {
            return $"https://www.mapquestapi.com/staticmap/v5/map?" +
                $"start={Uri.EscapeDataString(source)}" +
                $"&end={Uri.EscapeDataString(destination)}" +
                $"&size=600,400" +
                $"&key={apiKey}";
        }
    }

    public class RouteInfo
    {
        public float Distance { get; }
        public int Estimate { get; }
        public string ImageFileName { get; }

        public RouteInfo(float distance, int estimate, string imageFileName)
        {
            Distance = distance;
            Estimate = estimate;
            ImageFileName = imageFileName;
        }
    }
}

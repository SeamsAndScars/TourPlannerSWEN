using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner_Client.Models;

namespace TourPlanner_Client.Search
{
    public static class SearchExtensions
    {
        public static bool ContainsSearchQuery(this Tour tour, string searchQuery)
        {
            return tour.Name.ToLower().Contains(searchQuery.ToLower()) ||
                tour.Description.ToLower().Contains(searchQuery.ToLower()) ||
                tour.Source.ToLower().Contains(searchQuery.ToLower()) ||
                tour.Destination.ToLower().Contains(searchQuery.ToLower()) ||
                tour.ChildFriendlinessLabel.ToLower().Contains(searchQuery.ToLower()) ||
                tour.Popularity.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                tour.Ttype.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                tour.Estimate.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                tour.Id.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                tour.TourLogs.Any(log => log.ContainsSearchQuery(searchQuery));
        }

        public static bool ContainsSearchQuery(this TourLog tourLog, string searchQuery)
        {
            return tourLog.Comment.ToLower().Contains(searchQuery.ToLower()) ||
                tourLog.Time.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                tourLog.Date.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                tourLog.Rating.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                tourLog.Id.ToString().ToLower().Contains(searchQuery.ToLower()) ||
                tourLog.Difficulty.ToString().ToLower().Contains(searchQuery.ToLower());
                
        }

        
    }

}

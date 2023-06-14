using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TourPlanner_Client.Models;

namespace TourPlanner_Client.DAL.Database
{
    internal class TourRepository
    {
        public void Add(Tour tour)
        {
            using (var dbContext = new TourPlannerDbContext())
            {
                dbContext.Tours.Add(tour);
                dbContext.SaveChanges();
            }
        }
    }
}
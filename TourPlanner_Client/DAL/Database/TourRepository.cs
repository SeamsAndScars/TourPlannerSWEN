using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TourPlanner_Client.DAL.Database;
using TourPlanner_Client.Models;
using System.Threading.Tasks;





internal class TourRepository
{
    private readonly TourPlannerDbContext dbContext;
 
    public TourRepository()
    {
        dbContext = new TourPlannerDbContext();

    }

    // Create a new tour
    public void CreateTour(Tour tour)
    {
        dbContext.Tours.Add(tour);
        dbContext.SaveChanges();
    }

    // Get a tour
    public Tour GetTour(Guid tourId)
    {
        return dbContext.Tours.Find(tourId);
    }

    //Get TourLogs

    public TourLog GetTourLog(Guid tourId)
    {
        return dbContext.TourLogs.Find(tourId);
    }


    // Get all tours
    public List<Tour> GetTours()
    {
        return dbContext.Tours.ToList();
    }

    // Update a tour (modify)
    public void UpdateTour(Tour tour)
    {
        
            dbContext.Tours.Update(tour);
            dbContext.SaveChanges();
       
        
    }

    // Update a tourlog

    public void UpdateTourLog(TourLog tourLog)
    {
        
        try
        {
        dbContext.TourLogs.Update(tourLog);
        dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            //yo
        }
    }

    // Delete a tour
    public void DeleteTour(Guid tourId)
    {
        var tour = GetTour(tourId);
        if (tour != null)
        {
            dbContext.Tours.Remove(tour);
            dbContext.SaveChanges();
        }
    }

    public void AddTourLog(TourLog tourLog)
    {
       dbContext.TourLogs.Add(tourLog);

        try
        {
            tourLog.Date = tourLog.Date.ToUniversalTime();
            dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            //  exception message
        }
    }

    public List<TourLog> GetTourLogs(Guid tourId)
    {
        return dbContext.TourLogs.Where(tl => tl.TourId == tourId).ToList();
    }
}
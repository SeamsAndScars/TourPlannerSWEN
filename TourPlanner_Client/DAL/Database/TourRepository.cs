using System;
using System.Collections.Generic;
using System.Linq;
using TourPlanner_Client.DAL.Database;
using TourPlanner_Client.Models;

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
}
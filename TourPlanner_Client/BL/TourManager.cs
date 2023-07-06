﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TourPlanner_Client.DAL;
using TourPlanner_Client.Models;
using TourPlanner_Client.ViewModels;
using System.IO;
using TourPlanner_Client.APIs;
using System.Windows;
using System.Windows.Input;

namespace TourPlanner_Client.BL
{
    //hallo servus
    public class TourManager
    {
        private readonly TourRepository tourRepository;
        private readonly MapQuestService mapQuestService;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler TourModified;

        private static TourManager instance;
        public static TourManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new TourManager();

                return instance;
            }
        }

        public TourManager()
        {
            tourRepository = new TourRepository();
            mapQuestService = new MapQuestService("lejXayouqJddAgi89X1OcCGzJ2IjsBP8");
        }

        public List<Tour> GetTours()
        {
            List<Tour> tours = tourRepository.GetTours();
            return tours;
        }

        public List<TourLog> GetTourLogs(Tour tour)
        {
            List<TourLog> tourLogs = tourRepository.GetTourLogs(tour.Id);

            foreach (TourLog tourLog in tourLogs)
            {
                // Convert UTC time to CET time
                tourLog.Date = tourLog.Date.ToLocalTime();
            }

            return tourLogs;
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
                log.Error("Unexpected Error occured during MapQuest API call.");
                MessageBox.Show("Error during MapQuest API call");
            }
            OnTourModified();
        }

        public async Task AddTourLog(Tour selectedtour, AddTourLogViewModel viewModel)
        {
            if(viewModel is null)
            {
                // Handle the error case when the tour does not exist
                // TODO: Handle the error case
                log.Error("Unexpected issue during TourCreation, due to null ViewModel object.");
                MessageBox.Show("Unexpected issue during TourCreation.");
                return;
            }

            
            Tour existingTour = tourRepository.GetTour(selectedtour.Id);
            if (existingTour == null)
            {
                // Handle the error case when the tour does not exist
                // TODO: Handle the error case
                log.Error("Could not find Tour in Database.");
                MessageBox.Show("Could not find Tour in Database");
                return;
            }

            TourLog tourLog = new TourLog(existingTour.Id, viewModel.NonNullableSelectedDate, viewModel.Comment, viewModel.SelectedDifficulty, TimeOnly.MaxValue, viewModel.SelectedRating);
            tourRepository.AddTourLog(tourLog);
        }

        public async Task UpdateTour(EditTourViewModel tourViewModel)
        {
            Tour existingTour = tourRepository.GetTour(tourViewModel.Id);
            if (existingTour == null)
            {
                // Handle the error case when the tour does not exist
                // TODO: Handle the error case
                log.Error("Could not find Tour in Database.");
                MessageBox.Show("Could not find Tour in Database");
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
                    log.Error("Could not find Tour in Database.");
                    MessageBox.Show("Could not find Tour in Database");
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

            OnTourModified();
        }

        protected virtual void OnTourModified()
        {    
            TourModified?.Invoke(this, EventArgs.Empty);
        }
    }
}

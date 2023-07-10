using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TourPlanner_Client.BL;
using TourPlanner_Client.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;


namespace TourPlanner_Client.Commands
{
    public class ImportTourCommand : CommandBase
    {
        private readonly TourManager _tourManager;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ImportTourCommand(TourManager tourManager) 
        { 
            _tourManager = tourManager;
        }

        public override void Execute(object parameter)
        {
            //Retrieve Data before starting the Export
            List<Tour> tours = _tourManager.GetTours();
            foreach (Tour tour in tours)
            {
                tour.TourLogs = _tourManager.GetTourLogs(tour);
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = openFileDialog.FileName;

                string json = File.ReadAllText(filePath);
                List<Tour> importedTours = JsonConvert.DeserializeObject<List<Tour>>(json);

                foreach (Tour tour in importedTours)
                {
                    bool tourExists = tours.Any(existingTour => existingTour.Id == tour.Id);

                    if (!tourExists)
                    {
                        _tourManager.ImportTour(tour);
                    }
                }
            }
            else
            {
                log.Warn("No File was selected during Export");
            }
        }
    }
}

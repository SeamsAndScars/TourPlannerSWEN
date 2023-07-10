using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner_Client.BL;
using TourPlanner_Client.Stores;
using TourPlanner_Client.ViewModels;
using TourPlanner_Client.Models;
using Microsoft.Win32;
using System.Windows;
using Newtonsoft.Json;
using System.IO;

namespace TourPlanner_Client.Commands
{
    public class ExportTourCommand : CommandBase
    {
        private readonly TourManager _tourManager;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ExportTourCommand(TourManager tourManager)
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

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json";

            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = saveFileDialog.FileName;
                string json = JsonConvert.SerializeObject(tours, Formatting.Indented);

                // Save the JSON string to a file
                File.WriteAllText(filePath, json);
            }
            else
            {
                log.Warn("No File was selected during Export");
            }

        }
    }
}

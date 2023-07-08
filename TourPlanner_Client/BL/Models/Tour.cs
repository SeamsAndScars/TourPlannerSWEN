using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourPlanner_Client.Models
{
    public class Tour 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TourLog> TourLogs { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public TransportType Ttype { get; set; }
        public float Distance { get; set; }
        public int Estimate { get; set; }
        public string ImageFileName { get; set; }


        [NotMapped]
        public string NewImage { get; set; }

        public Tour(string Name, string Description, string Source, string Destination, TransportType ttype)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.Description = Description;
            this.Source = Source;
            this.Destination = Destination;
            TourLogs = new List<TourLog>();
            Ttype = ttype;
            Distance = 0;
            Estimate = 0;
            ImageFileName = string.Empty;
            NewImage = string.Empty;
        }
    }

    public enum TransportType
    {
        [Description("pedestrian")]
        Hike,
        [Description("fastest")]
        Car,
        [Description("bicycle")]
        Bike
    }
}

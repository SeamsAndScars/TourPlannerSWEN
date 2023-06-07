using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner_Client.Models
{
    public class Tour
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TourLogs>? TourLogs { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public _TransportType Ttype { get; set; }
        public float Distance { get; set; }
        public DateTime Estimate { get; set; }
        public object Image { get; set; }           //Needs to be changed later according to MapQuest image

        public Tour(string Name, string Description, string Source, string Destination, int ttype)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.Description = Description;
            this.Source = Source;
            this.Destination = Destination;
            TourLogs= new List<TourLogs>();
            Ttype = (_TransportType)ttype;
            Distance = 756;
            Estimate = new DateTime(7,5,7);
            Image = new object();
        }
    }


    public enum _TransportType
    {
        Hike,
        Run,
        Bike,
        Vacation
    }
}

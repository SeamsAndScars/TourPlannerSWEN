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
        public List<TourLogs>? TourLogs { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public _TransportType Ttype { get; set; }
        public float Distance { get; set; }
        public DateTime Estimate { get; set; }

        [NotMapped]
        public object Image { get; set; }

        public Tour(string Name, string Description, string Source, string Destination, _TransportType ttype)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.Description = Description;
            this.Source = Source;
            this.Destination = Destination;
            TourLogs = new List<TourLogs>();
            Ttype = ttype;
            Distance = 756;
            Estimate = new DateTime(7, 5, 7);
            Image = new object();
        }
    }

    public enum _TransportType
    {
        [Description("Hike")]
        Hike,
        [Description("Run")]
        Run,
        [Description("Bike")]
        Bike,
        [Description("Vacation")]
        Vacation
    }
}

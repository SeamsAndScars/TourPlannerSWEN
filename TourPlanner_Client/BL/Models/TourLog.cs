using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner_Client.Models
{
    public class TourLog
    {
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public Guid TourId { get; set; }
        public _Difficulty Difficulty { get; set; }
        public TimeOnly Time { get; set; }
        public _Rating Rating { get; set; }
        public Guid Id {get; set;}

        public TourLog(Guid tourId, DateTime date, string comment, _Difficulty difficulty, TimeOnly time, _Rating rating)
        {
            Id = Guid.NewGuid();
            TourId = tourId;
            Date = date;
            Comment = comment;
            Difficulty = difficulty;
            Time = time;
            Rating = rating;
        }
    }

    public enum _Difficulty
    {
        Simple,
        Advanced,
        Hard,
        Overkill 
    }

    public enum _Rating
    {
        Great,
        Good,
        Mediocre,
        Bad,
        Terrible
    }
}

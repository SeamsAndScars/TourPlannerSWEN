using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner_Client.Models
{
    public class TourLog
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public Guid TourId { get; set; }
        public Difficulty Difficulty { get; set; }
        public TimeOnly Time { get; set; }
        public Rating Rating { get; set; }
        

        public TourLog(Guid tourId, DateTime date, string comment, Difficulty difficulty, TimeOnly time, Rating rating)
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

    public enum Difficulty
    {
        Simple,
        Advanced,
        Hard,
        Overkill 
    }

    public enum Rating
    {
        Great,
        Good,
        Mediocre,
        Bad,
        Terrible
    }
}

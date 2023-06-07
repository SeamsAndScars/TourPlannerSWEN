using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner_Client.Models
{
    public class TourLogs
    {
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int Id { get; set; }
        public _Difficulty Difficulty { get; set; }
        public DateTime Time { get; set; }
        public _Rating Rating { get; set; }

        public TourLogs(DateTime date, string comment, int id, _Difficulty difficulty, DateTime time, _Rating rating)
        {
            Date = date;
            Comment = comment;
            Id = id;
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
        VeryBad,
        Bad,
        Mediocre,
        Good,
        Great
    }
}

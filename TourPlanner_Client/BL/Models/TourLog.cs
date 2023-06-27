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
        public int Id { get; set; }
        public _Difficulty Difficulty { get; set; }
        public TimeOnly Time { get; set; }
        public _Rating Rating { get; set; }

        public TourLog(DateTime date, string comment, int id, _Difficulty difficulty, TimeOnly time, _Rating rating)
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

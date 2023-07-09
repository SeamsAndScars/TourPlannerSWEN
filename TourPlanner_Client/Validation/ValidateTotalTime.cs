using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;

namespace TourPlanner_Client.Validation
{
    public class ValidateTotalTime
    {
        public bool ValidateTime(string time)
        {
            // Regular expression pattern for "hh:mm" format
            string pattern = @"^(0[0-9]|[1-9][0-9]?):[0-5][0-9]$";

            // Validate the time string against the pattern
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(time, pattern);

            // Show or hide error message based on validation result
            if (!isValid)
            {
                MessageBox.Show("Invalid time format. Please enter the time in the format 'hh:mm'.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return isValid;
        }
    }
}

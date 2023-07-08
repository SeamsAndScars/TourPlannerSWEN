using System;
using System.Globalization;
using System.Windows.Data;

namespace TourPlanner_Client.Converters
{
    public class SecondsToTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int seconds)
            {
                int hours = seconds / 3600;
                int minutes = (seconds % 3600) / 60;
                return string.Format("{0:00}:{1:00}", hours, minutes);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

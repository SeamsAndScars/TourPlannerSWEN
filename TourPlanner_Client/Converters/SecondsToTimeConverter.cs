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
                TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
                return timeSpan.ToString(@"hh\:mm\:ss");
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

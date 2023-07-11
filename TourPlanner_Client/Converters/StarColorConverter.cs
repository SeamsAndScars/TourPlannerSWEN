using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TourPlanner_Client.Converters
{
    public class StarColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isFavorite = (bool)value;

            if (isFavorite)
            {
                // Return yellow fill for favorite = true
                return Brushes.Yellow;
            }
            else
            {
                // Return a DrawingBrush with transparent fill and black stroke for favorite = false
                GeometryDrawing starDrawing = new GeometryDrawing
                {
                    Geometry = Geometry.Parse("M12,2 L15.09,8.39 L22,9 L17,13.42 L18.18,20 L12,16.8 L5.82,20 L7,13.42 L2,9 L8.91,8.39 Z"),
                    Brush = Brushes.Transparent,
                    Pen = new Pen(Brushes.Black, 1)
                };

                DrawingBrush starBrush = new DrawingBrush(starDrawing);

                return starBrush;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
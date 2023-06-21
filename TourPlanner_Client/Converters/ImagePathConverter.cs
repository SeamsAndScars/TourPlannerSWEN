using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TourPlanner_Client.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string fileName)
            {
                // Manually specify the base directory
                string baseDirectory = @"C:\Users\Jakob\OneDrive\Documents\GitHub\TourPlannerSWEN\TourPlanner_Client";

                // Construct the full image path
                string imagePath = Path.Combine(baseDirectory, "Images", fileName);

                // Create a BitmapImage and set its source to the image path
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(imagePath);
                image.EndInit();

                return image;
            }

            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

}

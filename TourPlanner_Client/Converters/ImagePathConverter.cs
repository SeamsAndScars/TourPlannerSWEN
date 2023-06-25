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
                string baseDirectory = Directory.GetCurrentDirectory();

                // Construct the full image path
                string imagePath = Path.Combine(baseDirectory, "Images", fileName);

                // Check if the image file exists
                if (File.Exists(imagePath))
                {
                    // Create a BitmapImage and set its source to the image path
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = new Uri(imagePath);
                    image.EndInit();

                    return image;
                }
                else
                {
                    // Image file not found, return a default image or null
                    // For example, you can return a placeholder image
                    // return new BitmapImage(new Uri("path_to_default_image"));
                    // Or return null
                    return null;
                }
            }

            return null;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

}

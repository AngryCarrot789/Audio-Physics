using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AudioPhysics.Converters
{
    public class BoolToIsPlayingIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isPlaying = (bool)value;
            return isPlaying
                ? new BitmapImage(new Uri(@"..\Resources\Stop.png", UriKind.Relative))
                : new BitmapImage(new Uri(@"..\Resources\Play.png", UriKind.Relative));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value == @"..\Resources\Stop.png";
        }
    }
}

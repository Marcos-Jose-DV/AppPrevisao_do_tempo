

using AppPrevisaoDoTempo.Models;
using System.Globalization;

namespace AppPrevisaoDoTempo.Convert;

class TempImageConvert : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {

        
        ImageSource image = (ImageSource)value;

        return image;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

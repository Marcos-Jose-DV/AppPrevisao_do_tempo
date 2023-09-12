using System.Globalization;

namespace AppPrevisaoDoTempo.Convert;

public class LongToDateTimeConverter : IValueConverter
{
    DateTime _time = new(1970, 1, 1, 0, 0, 0, 0, 0);
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        long dateTime = (long)value;
        return $"{_time.AddSeconds(dateTime).ToString(new CultureInfo("pt-BR"))} UTC";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

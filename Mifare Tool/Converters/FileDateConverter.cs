using System;
using Windows.UI.Xaml.Data;

namespace Mifare_Tool.Converters
{
    public class FileDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                DateTimeOffset dt = (DateTimeOffset)value;
                return Utils.Utils.dateFormatter.Format(dt);
            }
            else return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

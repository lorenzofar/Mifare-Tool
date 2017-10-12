using System;
using Windows.UI.Xaml.Data;

namespace Mifare_Tool.Converters
{
    public class NullBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var res = value != null;
            if (parameter != null) res = !res;
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

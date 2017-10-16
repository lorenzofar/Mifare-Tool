using System;
using Windows.UI.Xaml.Data;

namespace Mifare_Tool.Converters
{
    public class StatusBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null || !(bool)value)
                return App.Current.Resources["RedBrush"];
            return App.Current.Resources["GreenBrush"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

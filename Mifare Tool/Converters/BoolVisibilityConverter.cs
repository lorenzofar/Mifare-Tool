using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Mifare_Tool.Converters
{
    class BoolVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var visible = true;
            if (value == null || !(bool)value)
                visible = false;
            if (parameter != null) visible = !visible;
            return visible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

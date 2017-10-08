using System;
using Windows.UI.Xaml.Data;

namespace Mifare_Tool.Converters
{
    public class SectorTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return null;
            return String.Format(Utils.Utils.rLoader.GetString("sector_title"), (int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

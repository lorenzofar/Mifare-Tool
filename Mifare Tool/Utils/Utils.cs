using Windows.ApplicationModel.Resources;
using Windows.Globalization.DateTimeFormatting;

namespace Mifare_Tool.Utils
{
    public class Utils
    {
        private static ResourceLoader _rLoader;
        public static ResourceLoader rLoader
        {
            get
            {
                if (_rLoader == null)
                    _rLoader = new ResourceLoader();
                return _rLoader;
            }
        }

        public static DateTimeFormatter dateFormatter = new DateTimeFormatter("shortdate");
    }
}

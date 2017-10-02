using Windows.ApplicationModel.Resources;

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
    }
}

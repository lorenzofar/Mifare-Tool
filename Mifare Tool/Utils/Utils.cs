using MiFare.Classic;
using System.Collections.Generic;
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

        public static string SectorsToHexString(IReadOnlyList<Models.Sector> sectors)
        {
            var hexString = string.Empty;
            foreach(var sector in sectors)
            {
                var blocks = sector.blocks;
                for (int i = 0; i < blocks.Count; i++)
                    hexString += blocks[i].ByteArrayToString();
            }
            return hexString;
        }
    }
}

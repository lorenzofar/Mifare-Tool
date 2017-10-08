using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mifare_Tool.Viewmodels
{
    public class ViewModelLocator
    {
        private static MainViewModel _main;
        public static MainViewModel main
        {
            get
            {
                if (_main == null)
                    _main = new MainViewModel();
                return _main;
            }
        }

        private static FilesViewModel _files;
        public static FilesViewModel files
        {
            get
            {
                if (_files == null)
                    _files = new FilesViewModel();
                return _files;
            }
        }

        private static ReadingViewModel _reading;
        public static ReadingViewModel reading
        {
            get
            {
                if (_reading == null)
                    _reading = new ReadingViewModel();
                return _reading;
            }
        }
    }
}

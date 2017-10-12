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

        private static KeysViewModel _keys;
        public static KeysViewModel keys
        {
            get
            {
                if (_keys == null)
                    _keys = new KeysViewModel();
                return _keys;
            }
        }

        private static DumpsViewModel _dumps;
        public static DumpsViewModel dumps
        {
            get
            {
                if (_dumps == null)
                    _dumps = new DumpsViewModel();
                return _dumps;
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

        private static WritingViewModel _writing;
        public static WritingViewModel writing
        {
            get
            {
                if (_writing == null)
                    _writing = new WritingViewModel();
                return _writing;
            }
        }
    }
}

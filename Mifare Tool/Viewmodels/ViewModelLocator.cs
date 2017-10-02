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
    }
}

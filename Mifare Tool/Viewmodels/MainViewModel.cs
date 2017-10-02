using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Mifare_Tool.Viewmodels
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand<bool> _UpdateStatus;
        public RelayCommand<bool> UpdateStatus
        {
            get
            {
                if (_UpdateStatus == null)
                {
                    _UpdateStatus = new RelayCommand<bool>((bool available) =>
                    {

                    });
                }
                return _UpdateStatus;
            }
        }
    }
}

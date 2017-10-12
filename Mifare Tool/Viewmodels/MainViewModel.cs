using Template10.Mvvm;
using GalaSoft.MvvmLight.Command;
using Mifare_Tool.Views;
using Mifare_Tool.Utils;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Mifare_Tool.Models;

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

        private RelayCommand _OpenRead;
        public RelayCommand OpenRead
        {
            get
            {
                if (_OpenRead == null)
                    _OpenRead = new RelayCommand(async() =>
                    {
                        App.Current.NavigationService.Navigate(typeof(ReadingPage));
                    });
                return _OpenRead;
            }
        }

        private RelayCommand _OpenWrite;
        public RelayCommand OpenWrite
        {
            get
            {
                if (_OpenWrite == null)
                    _OpenWrite = new RelayCommand(async () =>
                    {
                        App.Current.NavigationService.Navigate(typeof(WritingPage));
                    });
                return _OpenWrite;
            }
        }

        private RelayCommand _OpenDumps;
        public RelayCommand OpenDumps
        {
            get
            {
                if (_OpenDumps== null)
                {
                    _OpenDumps = new RelayCommand(() =>
                    {
                        App.Current.NavigationService.Navigate(typeof(DumpsPage));
                    });
                }
                return _OpenDumps;
            }
        }

        private RelayCommand _OpenKeys;
        public RelayCommand OpenKeys
        {
            get
            {
                if (_OpenKeys == null)
                {
                    _OpenKeys = new RelayCommand(() =>
                    {
                        App.Current.NavigationService.Navigate(typeof(KeysPage));
                    });
                }
                return _OpenKeys;
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await CardManager.Initialize();
            return;
        }
    }
}

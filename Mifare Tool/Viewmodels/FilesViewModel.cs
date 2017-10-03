using Template10.Mvvm;
using GalaSoft.MvvmLight.Command;
using Mifare_Tool.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Mifare_Tool.Viewmodels
{
    public class FilesViewModel : ViewModelBase
    {
        private IReadOnlyList<StorageFile> _files;
        public IReadOnlyList<StorageFile> files
        {
            get { return _files; }
            set { Set(ref _files, value); }
        }


        private RelayCommand _ImportFile;
        public RelayCommand ImportFile
        {
            get
            {
                if (_ImportFile == null)
                    _ImportFile = new RelayCommand(() =>
                    {
                        FileManager.ImportFile();
                        RefreshFiles();
                    });
                return _ImportFile;
            }
        }

        private async void RefreshFiles()
        {
            files = await FileManager.ListFiles();
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            RefreshFiles();
            return Task.CompletedTask;
        }

    }
}

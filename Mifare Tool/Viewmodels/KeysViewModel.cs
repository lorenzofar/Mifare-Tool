using GalaSoft.MvvmLight.Command;
using Mifare_Tool.Models;
using Mifare_Tool.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.Storage;
using Windows.UI.Xaml.Navigation;

namespace Mifare_Tool.Viewmodels
{
    public class KeysViewModel : ViewModelBase
    {
        private IReadOnlyList<KeyFile> _files;
        public IReadOnlyList<KeyFile> files
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
                    _ImportFile = new RelayCommand(async () =>
                    {
                        await FileManager.ImportFile();
                        RefreshFiles();
                    });
                return _ImportFile;
            }
        }

        private RelayCommand _Refresh;
        public RelayCommand Refresh
        {
            get
            {
                if (_Refresh == null)
                    _Refresh = new RelayCommand(async () =>
                    {
                        RefreshFiles();
                    });
                return _Refresh;
            }
        }

        private RelayCommand<KeyFile> _Delete;
        public RelayCommand<KeyFile> Delete
        {
            get
            {
                if (_Delete == null)
                    _Delete = new RelayCommand<KeyFile>(async (file) =>
                    {
                        await FileManager.DeleteFile(file.file.Path);
                        if (file.isDefault) App.defaultKeyPath = null;
                        RefreshFiles();
                    });
                return _Delete;
            }
        }

        private RelayCommand<KeyFile> _SetDefault;
        public RelayCommand<KeyFile> SetDefault
        {
            get
            {
                if (_SetDefault == null)
                    _SetDefault = new RelayCommand<KeyFile>(file =>
                    {
                        App.defaultKeyPath = file.file.Path;
                        RefreshFiles();
                    });
                return _SetDefault;
            }
        }

        private async void RefreshFiles()
        {
            List<KeyFile> list = new List<KeyFile>();
            var rawFiles = await FileManager.ListFiles();
            //Search for the default file
            bool isDefaultSet = !string.IsNullOrWhiteSpace(App.defaultKeyPath);

            foreach (var file in rawFiles)
            {
                list.Add(new KeyFile()
                {
                    file = file,
                    isDefault = isDefaultSet ? file.Path == App.defaultKeyPath : false
                });
            }

            files = list;
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            RefreshFiles();
            return Task.CompletedTask;
        }

    }
}

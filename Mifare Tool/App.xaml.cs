using GalaSoft.MvvmLight.Messaging;
using Mifare_Tool.Models;
using Mifare_Tool.Views;
using System.Threading.Tasks;
using Template10.Common;
using Windows.ApplicationModel.Activation;
using Windows.Phone.UI.Input;
using Windows.Storage;

namespace Mifare_Tool
{
    sealed partial class App : BootStrapper
    {
        private static string _defaultKeyPath = null;
        public static string defaultKeyPath
        {
            get
            {
                return _defaultKeyPath;
            }
            set
            {
                _defaultKeyPath = value;
                Messenger.Default.Send<KeyEvent>(new KeyEvent { isKeyPresent = true });
                ApplicationData.Current.LocalSettings.Values["defaultKeyPath"] = value;
            }
        }

        public App()
        {
            this.InitializeComponent();
            var defaultKeySettings = ApplicationData.Current.LocalSettings.Values["defaultKeyPath"];
            if (defaultKeySettings != null) defaultKeyPath = defaultKeySettings.ToString();
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
                HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
                e.Handled = true;
            }
        }

        public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            NavigationService.Navigate(typeof(MainPage));
            return Task.CompletedTask;
        }

        public override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}

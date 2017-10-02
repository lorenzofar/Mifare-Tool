using Mifare_Tool.Views;
using System.Threading.Tasks;
using Template10.Common;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace Mifare_Tool
{
    sealed partial class App : BootStrapper
    {
        public App()
        {
            this.InitializeComponent();
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

using Mifare_Tool.Models;
using Mifare_Tool.Viewmodels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mifare_Tool.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KeysPage : Page
    {
        public KeysPage()
        {
            this.InitializeComponent();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;
            KeyFile file = (KeyFile)element.DataContext;

            if (file != null)
            {
                var vm = DataContext as KeysViewModel;
                vm?.Delete.Execute(file);
            }
        }

        private void setDefaultBtn_Click(object sender, RoutedEventArgs e)
        {
            var element = (FrameworkElement)sender;
            KeyFile file = (KeyFile)element.DataContext;

            if (file != null)
            {
                var vm = DataContext as KeysViewModel;
                vm?.SetDefault.Execute(file);
            }
        }
        
    }
}

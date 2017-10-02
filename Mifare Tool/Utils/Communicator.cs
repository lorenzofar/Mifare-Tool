using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Mifare_Tool.Utils
{
    public class Communicator
    {
        public static void SendPopup(string title, string message)
        {
            MessageDialog popup = new MessageDialog(Utils.rLoader.GetString(message), Utils.rLoader.GetString(title));
            popup.ShowAsync();
        }
    }
}

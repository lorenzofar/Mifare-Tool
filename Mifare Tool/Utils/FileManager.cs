using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace Mifare_Tool.Utils
{
    class FileManager
    {
        public static async void ImportFile()
        {
            //Get files from database
            FileOpenPicker file_picker = new FileOpenPicker();
            file_picker.FileTypeFilter.Add("*");
            var file = await file_picker.PickSingleFileAsync();
            if (file == null)
            {
                Communicator.SendPopup("file_null_title", "file_null_body");
                return;
            }
            try
            {
                await file.CopyAsync(ApplicationData.Current.LocalFolder, file.Name, NameCollisionOption.FailIfExists);
            }
            catch
            {
                Communicator.SendPopup("file_importErr_title", "file_duplicateErr_body");
            }
        }

        public static async Task<IReadOnlyList<StorageFile>> ListFiles()
        {
            var folder = ApplicationData.Current.LocalFolder;
            return await folder.GetFilesAsync();
        }
    }
}

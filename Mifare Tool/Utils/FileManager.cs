using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Mifare_Tool.Utils;
using MiFare.Classic;

namespace Mifare_Tool.Utils
{
    class FileManager
    {
        public static async Task ImportFile()
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

        public static async Task DeleteFile(string path)
        {
            var file = await StorageFile.GetFileFromPathAsync(path);
            if (file != null)
                await file.DeleteAsync();
        }

        public static async Task<StorageFile> GetFile(string path)
        {
            var keys_file = await StorageFile.GetFileFromPathAsync(path);
            if (keys_file == null)
                Communicator.SendPopup("file_null_title", "file_null_body");
            return keys_file;
        }

        public static async Task WriteDumpToFile(string hexString)
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.Unspecified;
            savePicker.FileTypeChoices.Add("Hex", new List<string>() { ".hex" });
            savePicker.SuggestedFileName = Utils.rLoader.GetString("dump_filename");
            StorageFile outFile = await savePicker.PickSaveFileAsync();
            if (outFile != null)
            {
                try
                {
                    // Writing directly to the picked file does not work, we have to first create a temporary file and then copy it to the desired location
                    StorageFile tempFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("tempExport", CreationCollisionOption.ReplaceExisting);
                    File.WriteAllBytes(tempFile.Path, hexString.StringToByteArray());
                    await tempFile.CopyAndReplaceAsync(outFile); 
                    Communicator.SendPopup("dump_export_success_title", "dump_export_success_body");
                }
                catch
                {
                    Communicator.SendPopup("dump_export_error_title", "dump_export_error_body");
                }
            }
        }

        public static async Task<IReadOnlyList<StorageFile>> ListFiles()
        {
            var folder = ApplicationData.Current.LocalFolder;
            return await folder.GetFilesAsync();
        }
    }
}

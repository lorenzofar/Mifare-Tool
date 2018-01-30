using Windows.Storage;

namespace Mifare_Tool.Models
{
    public class KeyFile
    {
        public StorageFile file { get; set; }
        public bool isDefault { get; set; }
    }
}

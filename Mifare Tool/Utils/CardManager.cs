using GalaSoft.MvvmLight.Messaging;
using MiFare;
using MiFare.Classic;
using Mifare_Tool.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Windows.Devices.SmartCards;
using Windows.Storage;

namespace Mifare_Tool.Utils
{
    public class CardManager
    {
        private const int SECTORS_COUNT = 16;

        private static SmartCardReader reader = null;
        private static MiFareCard card = null;

        private static List<SectorKeySet> _keys = new List<SectorKeySet>();
        public List<SectorKeySet> keys { get { return _keys; } }

        public static async Task<bool> Initialize()
        {
            if (reader == null)
                try
                {
                    reader = await CardReader.FindAsync();
                    if (reader == null) throw new Exception();
                    reader.CardAdded += Reader_CardAdded;
                    reader.CardRemoved += Reader_CardRemoved;
                    return true;
                }
                catch
                {
                    return false;
                }
            else return true;
        }

        #region CARD HANDLERS
        private static void Reader_CardRemoved(SmartCardReader sender, CardRemovedEventArgs args)
        {
            card = null;
            RaiseStatusUpdate(false);
        }

        private static void Reader_CardAdded(SmartCardReader sender, CardAddedEventArgs args)
        {
            card = args.SmartCard.CreateMiFareCard();
            RaiseStatusUpdate(true);
        }

        private static void RaiseStatusUpdate(bool status)
        {
            Messenger.Default.Send<CardEvent>(new CardEvent { isCardPresent = status });
        }
        #endregion

        public static async Task<IReadOnlyList<Models.Sector>> ReadCard()
        {
            int i = 0;
            List<Models.Sector> sectors = new List<Models.Sector>();
            while (i < SECTORS_COUNT)
            {
                List<byte[]> blocks = await ReadSector(i);
                Models.Sector newSector = new Models.Sector()
                {
                    index = i,
                    keyA = _keys[i].Key,
                    keyB = _keys[i + SECTORS_COUNT].Key,
                    blocks = blocks
                };
                sectors.Add(newSector);
                i++;
            }
            return sectors;
        }

        private static async Task<List<byte[]>> ReadSector(int sector)
        {
            try
            {
                if (card == null) throw new Exception();
                List<byte[]> blocks = new List<byte[]>();
                var _sector = card.GetSector(sector);
                for (int i = 0; i < _sector.NumDataBlocks; i++)
                {
                    var block = await _sector.GetData(i);
                    blocks.Add(block);
                }
                return blocks;
            }
            catch
            {
                return null;
            }
        }

        public static async Task GetKeysFromFile(string path)
        {
            try
            {
                var keys_file = await StorageFile.GetFileFromPathAsync(path);
                if (keys_file == null)
                {
                    Communicator.SendPopup("file_null_title", "file_null_body");
                    return;
                }

                using (var inputStream = await keys_file.OpenReadAsync())
                using (var classicStream = inputStream.AsStreamForRead())
                using (var streamReader = new StreamReader(classicStream))
                {
                    int sector = 0;
                    _keys.Clear();
                    while (streamReader.Peek() >= 0)
                    {
                        var new_key = new SectorKeySet
                        {
                            Sector = sector < SECTORS_COUNT ? sector : sector - SECTORS_COUNT,
                            Key = streamReader.ReadLine().StringToByteArray(),
                            KeyType = sector < SECTORS_COUNT ? KeyType.KeyA : KeyType.KeyB
                        };
                        _keys.Add(new_key);
                        sector++;
                    }
                }
                SetKeys();
                Communicator.SendPopup("import_success_title", "import_success_body");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private static void SetKeys()
        {
            if (_keys != null)
                foreach (var key in _keys) card.AddOrUpdateSectorKeySet(key);
            else throw new Exception("Empty keys list");
        }
    }
}

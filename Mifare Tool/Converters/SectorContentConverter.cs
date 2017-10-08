using MiFare.Classic;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Mifare_Tool.Converters
{
    public class SectorContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return null;
            var sector = (Models.Sector)value;
            byte[] keyA = sector.keyA, keyB = sector.keyB;
            if (sector.blocks == null) return null;
            var blocks = sector.blocks;
            var blocks_num = blocks.Count;
            int i = 1;
            var container = new StackPanel();
            for (i = 0; i < blocks_num; i++)
            {
                var block = blocks[i];
                if (i == blocks_num - 1)
                {
                    block = PutKeysInTrailer(block, sector.keyA, sector.keyB);
                    container.Children.Add(colorTrailer(block, keyA, keyB));
                    break;
                }
                var row = new StackPanel() { Orientation = Orientation.Horizontal };
                //TODO: Color blocks according to their type
                row.Children.Add(new TextBlock()
                {
                    Text = block.ByteArrayToString()
                });
                container.Children.Add(row);
            }
            return container;
        }

        private byte[] PutKeysInTrailer(byte[] block, byte[] keyA, byte[] keyB)
        {
            int i, start;
            for (i = 0; i < keyA.Length; i++)
                block[i] = keyA[i];
            start = block.Length - keyB.Length;
            for (i = start; i < block.Length; i++)
                block[i] = keyB[i - start];
            return block;
        }

        private StackPanel colorTrailer(byte[] block, byte[] keyA, byte[] keyB)
        {
            var row = new StackPanel() { Orientation = Orientation.Horizontal };
            string ka_s = keyA.ByteArrayToString();
            string kb_s = keyB.ByteArrayToString();
            string block_s = block.ByteArrayToString();
            row.Children.Add(new TextBlock()
            {
                Text = ka_s,
                Foreground = (SolidColorBrush)App.Current.Resources["KeyBrush"]
            });
            block_s = block_s.Substring(ka_s.Length);
            block_s = block_s.Substring(0, block_s.Length - kb_s.Length);
            row.Children.Add(new TextBlock()
            {
                Text = block_s,
                Foreground = (SolidColorBrush)App.Current.Resources["AccessCondsBrush"]
            });
            row.Children.Add(new TextBlock()
            {
                Text = kb_s,
                Foreground = (SolidColorBrush)App.Current.Resources["KeyBrush"]
            });
            return row;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

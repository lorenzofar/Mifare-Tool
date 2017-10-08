using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mifare_Tool.Models
{
    public class Sector
    {
        public int index { get; set; }
        public byte[] keyA { get; set; }
        public byte[] keyB { get; set; }
        public List<byte[]> blocks { get; set; }
    }
}

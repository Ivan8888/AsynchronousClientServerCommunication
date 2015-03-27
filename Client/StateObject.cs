using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Client
{
    public class StateObject
    {
        public Socket Socket = null;
        public const int bufferSize = 38;
        public byte[] buffer = new byte[bufferSize];
    }
}

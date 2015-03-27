using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse("127.0.0.1");
            server.Bind(new IPEndPoint(address, 10000));
            server.Listen(5);
            Socket client = server.Accept();
            Console.WriteLine("Client connected!");
            Random rand = new Random();
            for (; ; )
            {
                client.Send(Encoding.ASCII.GetBytes("name=Prod1|symbol=SYMBOL1|currency=RSD"));
                client.Send(Encoding.ASCII.GetBytes("name=Prod2|symbol=SYMBOL2|currency=RSD"));
                client.Send(Encoding.ASCII.GetBytes("name=Prod1|symbol=SYMBOL1|currency=EUR"));
                client.Send(Encoding.ASCII.GetBytes("name=Prod3|symbol=SYMBOL3|currency=USD"));
                client.Send(Encoding.ASCII.GetBytes("symbol=SYMBOL2|quantity=" + rand.Next(100, 500) + "|price=" + rand.Next(1000, 2000)));
                client.Send(Encoding.ASCII.GetBytes("symbol=SYMBOL3|quantity=" + rand.Next(100, 500) + "|price=" + rand.Next(1000, 2000)));
                client.Send(Encoding.ASCII.GetBytes("symbol=SYMBOL1|quantity=" + rand.Next(100, 500) + "|price=" + rand.Next(1000, 2000)));
                client.Send(Encoding.ASCII.GetBytes("symbol=SYMBOL3|quantity=" + rand.Next(100, 500) + "|price=" + rand.Next(1000, 2000)));
            }

            //Console.ReadKey();
        }
    }
}

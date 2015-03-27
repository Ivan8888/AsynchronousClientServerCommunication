using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Domen;
using DatabaseCommunication;
using System.Globalization;

namespace Client
{
   public class Communication
    {
       Broker broker = new Broker();

        private void parseData(string data)
        {
            int pos = 0;
            pos = data.IndexOf("=");
            string word = data.Substring(0, pos);
            //if the first word is "name" I have ProductInfo(reference information) else I have ProductOrder(data feed).
            if (word == "name")
            {
                //parse reference information
                parseProduct(data, pos);
            }
            else
            {
                //parse data feed
                parseOrder(data, pos);
            }               
        }

        private void parseProduct(string data, int pos)
        {
            ProductInfo product = new ProductInfo();

            int posn = 0;
            string name;
            string simbol;
            string currency;
            //get name
            posn = data.IndexOf("|");
            name = data.Substring(pos + 1, posn - pos - 1);
            //get simbol
            pos = data.IndexOf("=", posn);
            posn = data.IndexOf("|", pos);
            simbol = data.Substring(pos + 1, posn - pos - 1);
            //get currency
            pos = data.IndexOf("=", posn);
            posn = data.Length;
            currency = data.Substring(pos + 1, posn - pos - 1);
            //initialize product object
            product.FullName = name;
            product.Simbol = simbol;
            product.Currency = currency;
            //insert ProductInfo in database or update  if alreday exist.
            broker.InsertOrUpdateProductInfo(product);
        }

        private void parseOrder(string data, int pos)
        {
            ProductOrder order = new ProductOrder();

            int posn = 0;
            string simbol;
            int quantity;
            decimal price;
            //get simbol
            posn = data.IndexOf("|");
            simbol = data.Substring(pos + 1, posn - pos - 1);
            //get quantity
            pos = data.IndexOf("=", posn);
            posn = data.IndexOf("|", pos);
            quantity = Int32.Parse(data.Substring(pos + 1, posn - pos - 1));
            //get price
            pos = data.IndexOf("=", posn);
            posn = data.Length;
            price = Decimal.Parse(data.Substring(pos + 1, posn - pos - 1));
            //initilaze the order object
            order.Simbol = simbol;
            order.Quantity = quantity;
            order.Price = price;

            // insert new ProductOrder in database
            broker.insertProductOrder(order);
        }
       
         private IPEndPoint createRemoteEP()
         {
             IPAddress remoteAddress = IPAddress.Parse("127.0.0.1");
             IPEndPoint remoteEP = new IPEndPoint(remoteAddress, 10000);
             return remoteEP;
         }

        public void startClient()
        {
           
            //begin connect to server, this will create new thread that will finished connection without blocking main thread
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.BeginConnect(createRemoteEP(), new AsyncCallback(connectCallback), client);
            }
            catch(Exception e)
            {
                throw(e);          
            }        
        }

        private void connectCallback(IAsyncResult result)
        {
            //connect is finished on deferente thread
            Socket client = result.AsyncState as Socket;
            try
            {
                client.EndConnect(result);
                //if the connection success, start the reciveing data, first the state object is created
                StateObject stateObject = new StateObject();
                stateObject.Socket = client;
                //start reciveing data if data is avilable. Reciveing will continue in separate thread
                if (client.Poll(-1, SelectMode.SelectRead))
                {
                    stateObject.Socket.BeginReceive(stateObject.buffer, 0, StateObject.bufferSize, SocketFlags.None, new AsyncCallback(reciveCallback), stateObject);
                }
            }
            catch (Exception e)
            {
                throw(e);
            }        
        }

        private void reciveCallback(IAsyncResult result)
        {
            // giving the name to the threads just for test
            //Random rand = new Random();
            //Thread.CurrentThread.Name = "Thread " + rand.Next(1, 10);

            //that calture make me a problem with . and , in double type, but now i am using decimal
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            
                    
            //retrive the state object
            StateObject stateObject = result.AsyncState as StateObject;
            // call EndReceive which will give us the number of bytes received
            int numBytesRec = 0;
            numBytesRec = stateObject.Socket.EndReceive(result);
            //copy recived data from the buffer to the packet, because i need array that will have just recive bytes without blank filds.
            byte[] packet = new byte[numBytesRec];
            Array.Copy(stateObject.buffer, packet, packet.Length);
            //create new buffer because i need clear buffer for next recive action
            stateObject.buffer = new byte[StateObject.bufferSize];
            //every time empty the string first and then insert the packet in string fild
            string response = "";
            response = Encoding.ASCII.GetString(packet);
            //this thread calling function that will parse the passed data and write in database
            parseData(response);
            //caling new begin recieve method that will make new thread, and that thread will also call parseData function
            //and we have write in database from the deferente thread at the same time
            if (stateObject.Socket.Poll(-1, SelectMode.SelectRead))
            {
                stateObject.Socket.BeginReceive(stateObject.buffer, 0, StateObject.bufferSize, SocketFlags.None, new AsyncCallback(reciveCallback), stateObject);
            }
        }
    }
}

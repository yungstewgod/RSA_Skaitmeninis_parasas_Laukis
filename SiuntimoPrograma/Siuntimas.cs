using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SiuntimoPrograma
{
    class Siuntimas
    {
        private string ip;
        private int port;

        public Siuntimas(string ip = "127.0.0.1", int port = 2021)
        {
            this.ip = ip;
            this.port = port;
        }

        public void Send(string message)
        {
            IPAddress receiverIP = IPAddress.Parse(ip); // receiver adresas
            IPEndPoint endPoint = new IPEndPoint(receiverIP, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(endPoint);
            socket.Send(Encoding.ASCII.GetBytes(message));
            socket.Close();
        }
    }
}

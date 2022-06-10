using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GavejoPrograma
{
    class Gavejas
    {
        private static TcpListener listener = null;
        public delegate void UpdateResult(Package package);
        public UpdateResult updateResult;
        public delegate void TroubleAndMakeItDouble(string message);
        public TroubleAndMakeItDouble troubleAndMakeItDouble;

        public Gavejas(UpdateResult updateResult, TroubleAndMakeItDouble troubleAndMakeItDouble, string ip = "127.0.0.1", int port = 2021)
        {
            this.updateResult = updateResult;
            this.troubleAndMakeItDouble = troubleAndMakeItDouble;

            if (listener == null)
                listener = new TcpListener(IPAddress.Parse(ip), port);
        }

        public void Start()
        {
            try
            {
                listener.Start();
                while (true)
                {
                    using (var client = listener.AcceptTcpClient())
                    using (var stream = client.GetStream())
                    {

                        byte[] data = new byte[1024];
                        using (MemoryStream ms = new MemoryStream())
                        {

                            int numBytesRead;
                            while ((numBytesRead = stream.Read(data, 0, data.Length)) > 0)
                            {
                                ms.Write(data, 0, numBytesRead);
                            }

                            Package package = new Package();
                            Console.WriteLine(Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length));
                            package.Parse(Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length));
                            updateResult(package);

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                troubleAndMakeItDouble(exc.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }

        public void Stop()
        {
            listener.Stop();
            listener = null;
        }
    }
}
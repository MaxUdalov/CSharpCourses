using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Chat_Client
{
    class Client
    {
        static TcpClient server = new TcpClient();
        static string name;
        public static void Start()
        {
            try
            {
                Console.Write("User name: ");
                name = Console.ReadLine();
                server.Connect("127.0.0.1", 777);
                Thread thSend = new Thread(Send);
                thSend.Start();
                Thread thReceive = new Thread(Receive);
                thReceive.Start();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
        static void Receive()
        {
            while (true)
            {
               
                byte[] inBytes = new byte[256];
                string inData = null;
                int i;
                NetworkStream stream = server.GetStream();
                while ((i = stream.Read(inBytes, 0, inBytes.Length)) != 0)
                {
                    inData = System.Text.Encoding.ASCII.GetString(inBytes, 0, i);
                    Console.WriteLine("Server: {0}", inData);
                    stream.Flush();
                }
            }
        }
        static void Send()
        {
            while (true)
            {
                Thread.Sleep(20);
                Console.Write("{0}: ", name);
                string outData = Console.ReadLine();
                byte[] outBytes = System.Text.Encoding.ASCII.GetBytes(outData);
                NetworkStream stream = server.GetStream();
                stream.Write(outBytes, 0, outBytes.Length);
                stream.Flush();
            }
        }
    }
}

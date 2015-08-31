using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Server_Chat
{
    class Server
    {
        static List<NetworkStream> listStream = new List<NetworkStream>();
        static List<TcpClient> listClient = new List<TcpClient>();
        static readonly int port = 777;
        public static void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Console.WriteLine("Server Started!");
            int i = 0;
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                listClient.Add(client);
                listStream.Add(listClient[i].GetStream());
                Thread thread = new Thread(Send);
                thread.Start(i++);
            }
        }

        static void Send(object value)
        {
            int numStream =(int) value;
            while (true)
            {
                
                int i;
                byte[] inBytes = new byte[256];
                string inData = null;
                while ((i = listStream[numStream].Read(inBytes, 0, inBytes.Length)) != 0)
                {
                    inData = System.Text.Encoding.ASCII.GetString(inBytes, 0, i);
                    Console.WriteLine("Received : {0}", inData);

                    byte[] outBytes = System.Text.Encoding.ASCII.GetBytes(inData.ToUpper());
                    for (int count = 0; count < listStream.Count(); count++ )
                        if(count!=numStream)
                        listStream[count].Write(outBytes, 0, outBytes.Length);
                    inData = null;
                    listStream[numStream].Flush();
                }
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Diagnostics;

namespace Server_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Start();
        }
    }
}
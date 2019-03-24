using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class Protocol
    {
        //private static TcpClient client = new TcpClient("127.0.0.1", 12345);
        //private static StreamReader reader = new StreamReader(client.GetStream(), Encoding.UTF8);
        //private static StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.UTF8);

        public string FirstMessageSender(FirstMessage firstmessage)
        {
            return JsonConvert.SerializeObject(firstmessage.Token);
        }

        public string MessageSender(Response response)
        {
            return JsonConvert.SerializeObject(response);
        }
    }
}

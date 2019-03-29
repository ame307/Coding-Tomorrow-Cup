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
        public void FirstMessageSender(FirstMessage firstmessage)
        {
            TcpClient tcpClient;
            NetworkStream networkStream;
            StreamWriter streamWriter;
            try
            {
                tcpClient = new TcpClient("31.46.64.35", 12323);
                networkStream = tcpClient.GetStream();
                JObject token = new JObject();
                token.Add("token", FirstMessage.Firstmessage().Token);
                streamWriter = new StreamWriter(networkStream);
                streamWriter.Write(token.ToString());
                streamWriter.Flush();

                if (networkStream.CanRead)
                {
                    byte[] bytes = new byte[tcpClient.ReceiveBufferSize];                    
                    networkStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);       
                    List<byte> realValue = new List<byte>();
                    int i = 0;
                    while (bytes[i] != 0) {
                        realValue.Add(bytes[i]);
                        i++;
                    }
                    string returndata = Encoding.UTF8.GetString(realValue.ToArray());
                    TickProcessor processor = new TickProcessor(returndata);
                    Console.WriteLine(processor.GetGameId());

                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string MessageSender(Response response)
        {
            return JsonConvert.SerializeObject(response);
        }
    }
}

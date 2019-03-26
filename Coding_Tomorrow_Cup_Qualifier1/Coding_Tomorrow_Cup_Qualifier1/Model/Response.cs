using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    public class Response
    {
        private  TickProcessor tp = new TickProcessor(Path.Combine(Path.GetFullPath(@"..\..\"), "Resources/TickExample.json"));
        //private TickProcessor tp = new TickProcessor(new Uri("http://www.facebook.com/"));
        public int GameId { get; set; }

        public int Tick { get; set; }

        public int CarId { get; set; }

        public string Command { get; set; }

        public Response(int gameId, int tick, int carId, string command)
        {
            GameId = gameId;
            Tick = tick;
            CarId = carId;
            Command = command;
        }  

        private string Output(Response response)
        {
            response.GameId = tp.GetGameId();
            response.Tick = tp.GetTick();
            response.CarId = tp.GetCarId();
            response.Command = Command;
            return JsonConvert.SerializeObject(response);
        }

        public static List<string> GetResponseFromDirections(List<string> legrovidebbut)
        {
            List<string> responses = new List<string>();
            Response temp;
            for (int i = 0; i < legrovidebbut.Count; i++)
            {
                temp = new Response(1, i + 2, 1, legrovidebbut[i]);
                responses.Add(JsonConvert.SerializeObject(temp));
            }
            return responses;
        }
    }
}

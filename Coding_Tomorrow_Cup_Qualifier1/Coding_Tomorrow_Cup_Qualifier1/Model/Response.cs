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
        TickProcessor tp = new TickProcessor(Path.Combine(Path.GetFullPath(@"..\..\"), "Resources/TickExample.json"));

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

        public string Output(Response response)
        {
            response.GameId = tp.GetGameId();
            response.Tick = tp.GetTick();
            response.CarId = tp.GetCarId();
            response.Command = Command;
            return JsonConvert.SerializeObject(response);
        }
    }
}

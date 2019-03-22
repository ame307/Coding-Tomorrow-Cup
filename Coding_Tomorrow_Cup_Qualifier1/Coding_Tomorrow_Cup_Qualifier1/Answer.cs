using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class Response
    {
        public int GameId { get; set; }

        public int Tick { get; set; }

        public int CarId { get; set; }

        public string Command { get; set; }

        public Response(int gameId, int tick, int carId, string command)
        {
            GameId = gameId;
            Tick = tick;
            CarId = carId;
            Command = Command;
        }
    }
}

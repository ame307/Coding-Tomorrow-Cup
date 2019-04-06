using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class WriteOutData
    {
        public void WriteOutMessages(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        public void WriteOutCommands(string cmd)
        {
            Console.WriteLine("\n\nÚtvonal utasítás: {0}",cmd);
            
        }

        public void WriteOutRoutePositions(List<Pos> routePositions)
        {
            Console.WriteLine("\n\nÚtvonal pozíciók:");
            for (int i = 0; i < routePositions.Count; i++)
            {
                Console.WriteLine("({0};{1})", routePositions[i].PosX, routePositions[i].PosY);
            }
        }

        public string Response(Protocol p, string json)
        {
            Console.WriteLine("Elküldött parancs: {0}", json);
            string response = p.MessageSender(json);
            Console.WriteLine("Szerver válasza: {0}", response);
            return response;
        }

        public void GetNearestPassangerPosition(List<Car> cars, Passenger nearestPassenger)
        {
            Console.WriteLine("Kocsi induló pozíció: ({0};{1})", cars[0].Position.PosX, cars[0].Position.PosY);
            Console.WriteLine("Kocsi iránya: {0}", cars[0].Direction);
            Console.WriteLine("Legközelebbi utas:\nId:{0}\nPosition: ({1};{2})\nDestiny position: ({3};{4})", nearestPassenger.Id, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY, nearestPassenger.DestinyPosition.PosX, nearestPassenger.DestinyPosition.PosY);
        }

        public void GetPathandEndPoint(List<Car> cars, Passenger nearestPassenger)
        {
            Console.WriteLine("-------Útvonal keresése--------");
            Console.WriteLine("Kocsi induló pozíció: ({0};{1})", cars[0].Position.PosX, cars[0].Position.PosY);
            Console.WriteLine("Végpont: ({0};{1})", nearestPassenger.DestinyPosition.PosX, nearestPassenger.DestinyPosition.PosY);
        }
    }
}

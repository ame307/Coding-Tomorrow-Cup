using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Test
            TickProcessor tp = new TickProcessor(Path.Combine(Path.GetFullPath(@"..\..\"), "Resources/TickExample.json"));
            private TickProcessor tp = new TickProcessor(new Uri("http://www.facebook.com/"));
            Console.WriteLine(tp.GetGameId());
            Console.WriteLine(tp.GetTick());
            Console.WriteLine(tp.GetCarId());

            Car[] cars = tp.GetCars();
            Pedestrian[] pedestrians = tp.GetPedestrians();
            Passenger[] passengers = tp.GetPassengers();
            string[] messages = tp.GetMessages();

            Console.WriteLine("Cars:");
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i].Id);
                Console.WriteLine(cars[i].Position.PosX + "," + passengers[i].Position.PosY);
                Console.WriteLine(cars[i].Life);
                Console.WriteLine(cars[i].Speed);
                Console.WriteLine(cars[i].Direction);
                Console.WriteLine(cars[i].NextCommand);
                Console.WriteLine(cars[i].TransportedPedestrians);
                Console.WriteLine(cars[i].PassengerId);
                Console.WriteLine("-------------------------------------");
            }

            Console.WriteLine("Pedestrians:");
            for (int i = 0; i < pedestrians.Length; i++)
            {
                Console.WriteLine(pedestrians[i].Id);
                Console.WriteLine(pedestrians[i].Position.PosX + "," + passengers[i].Position.PosY);
                Console.WriteLine(pedestrians[i].Speed);
                Console.WriteLine(pedestrians[i].Direction);
                Console.WriteLine(pedestrians[i].NextCommand);
                Console.WriteLine("-------------------------------------");

            }

            Console.WriteLine("Passengers:");
            for (int i = 0; i < passengers.Length; i++)
            {
                Console.WriteLine(passengers[i].Id);
                Console.WriteLine(passengers[i].Position.PosX + "," + passengers[i].Position.PosY);
                Console.WriteLine(passengers[i].DestinyPosition.PosX + "," + passengers[i].DestinyPosition.PosY);
                Console.WriteLine(passengers[i].CarId);
                Console.WriteLine("-------------------------------------");
            }

            Console.WriteLine("Messages:");
            for (int i = 0; i < messages.Length; i++)
            {
                Console.WriteLine(messages[i]);
                Console.WriteLine("-------------------------------------");
            }*/


            //Car kocsi = new Car(01, new Pos(28, 56), 100, 0, ">", "0", 0, 0);


            Routing path = Routing.GetInstance();
            List<string> legrovidebbut = path.FindRoute(28, 56, 28, 46).ToDirections();
            List<string> responses = Response.GetResponseFromDirections(legrovidebbut);
            for (int i = 0; i < responses.Count - 1; i++)
                Console.WriteLine(responses[i]);
            Console.ReadKey();
        }
    }
    
}

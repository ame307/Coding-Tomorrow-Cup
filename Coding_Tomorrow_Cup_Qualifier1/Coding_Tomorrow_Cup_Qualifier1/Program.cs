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


            /*
            TickProcessor tp = new TickProcessor(Path.Combine(Path.GetFullPath(@"..\..\"), "Resources/TickExample.json"));
            //private TickProcessor tp = new TickProcessor(new Uri("http://www.facebook.com/"));
            Console.WriteLine(tp.GetGameId());
            Console.WriteLine(tp.GetTick());
            Console.WriteLine(tp.GetCarId());

            Car[] cars = tp.GetCars();
            Pedestrian[] pedestrians = tp.GetPedestrians();
            Passenger[] passengers = tp.GetPassengers();
            string[] messages = tp.GetMessages();
            Routing path = Routing.GetInstance();
            List<string> responses;
            List<string> commands;

            int nearestPassangerDistance = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosX, passengers[0].Position.PosX, passengers[0].Position.PosY).ToPositions().Count;
            Passenger nearestPassanger = passengers[0];
            for (int i = 1; i < passengers.Length; i++)
            {
                int passangerDistance = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosX, passengers[i].Position.PosX, passengers[i].Position.PosY).ToPositions().Count;
                if (nearestPassangerDistance > passangerDistance)
                {
                    nearestPassanger = passengers[i];
                }
            }
            commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosX, nearestPassanger.Position.PosX, nearestPassanger.Position.PosY).ToDirections());
            responses = Response.GetResponseFromDirections(commands);

            //

            commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosX, nearestPassanger.DestinyPosition.PosX, nearestPassanger.DestinyPosition.PosY).ToDirections());
            responses = Response.GetResponseFromDirections(commands);*/

            /*Car car = new Car(1, new Pos(30, 46), 100, 0, ">", "NO_OP", 0, 0);
            Routing route = Routing.GetInstance();
            List<string> directions = route.FindRoute(car.Position.PosX, car.Position.PosY, 31, 56).ToDirections();
            List<string> commands = car.CreateCommands(directions);
            List<string> responses = Response.GetResponseFromDirections(commands);
            for (int i = 0; i < responses.Count; i++)
            {
                Console.WriteLine(responses[i]);
            }*/
            Protocol p = new Protocol();
            FirstMessage fm = FirstMessage.Firstmessage();
            Console.WriteLine(p.FirstMessageSender(fm));

            Console.ReadKey();
        }
    }
}

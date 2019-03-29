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



            Protocol p = new Protocol();
            FirstMessage fm = FirstMessage.Firstmessage();
            TickProcessor tp = new TickProcessor(p.FirstMessageSender(fm));

            List<Car> cars = new List<Car>();
            List<Pedestrian> pedestrians = new List<Pedestrian>();
            List<Passenger> passengers = new List<Passenger>();
            List<string> messages = new List<string>();
            Routing path = Routing.GetInstance();
            List<string> commands = new List<string>();

            int y;
            bool IsFindPassanger = true;

            while(true)
            {
                y = 0;
                if(y >= commands.Count || commands.Count == 0)
                {

                    cars = tp.GetCars();
                    pedestrians = tp.GetPedestrians();
                    passengers = tp.GetPassengers();
                    messages = tp.GetMessages();

                    Passenger nearestPassanger = new Passenger();

                    if (IsFindPassanger)
                    {
                        int nearestPassangerDistance = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosX, passengers[0].Position.PosX, passengers[0].Position.PosY).ToPositions().Count;
                        nearestPassanger = passengers[0];
                        for (int i = 1; i < passengers.Count; i++)
                        {
                            int passangerDistance = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosX, passengers[i].Position.PosX, passengers[i].Position.PosY).ToPositions().Count;
                            if (nearestPassangerDistance > passangerDistance)
                            {
                                nearestPassanger = passengers[i];
                            }
                        }

                        commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosX, nearestPassanger.Position.PosX, nearestPassanger.Position.PosY).ToDirections());

                        IsFindPassanger = false;
                    }
                    else
                    {
                        commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosX, nearestPassanger.DestinyPosition.PosX, nearestPassanger.DestinyPosition.PosY).ToDirections());
                    }

                    Response  = new Response();

                    y = 0;
                }
                else
                {
                    y++;
                } 
                
            }










            /*Car car = new Car(1, new Pos(30, 46), 100, 0, ">", "NO_OP", 0, 0);
            Routing route = Routing.GetInstance();
            List<string> directions = route.FindRoute(car.Position.PosX, car.Position.PosY, 31, 56).ToDirections();
            List<string> commands = car.CreateCommands(directions);
            List<string> responses = Response.GetResponseFromDirections(commands);
            for (int i = 0; i < responses.Count; i++)
            {
                Console.WriteLine(responses[i]);
            }*/




            Console.ReadKey();
        }
    }
}

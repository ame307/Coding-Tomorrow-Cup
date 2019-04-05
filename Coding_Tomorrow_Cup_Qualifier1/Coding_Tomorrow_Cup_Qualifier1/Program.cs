using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class Program
    {
        static WriteOutData wod = new WriteOutData();

        static List<Pos> routePositions = new List<Pos>();
        static void Main(string[] args)
        {
            #region Declarations
            Protocol p = new Protocol();
            FirstMessage fm = FirstMessage.Firstmessage();
            TickProcessor tp = new TickProcessor(p.FirstMessageSender(fm));

            List<string> messages;
            List<string> commands = new List<string>();

            List<Car> cars;
            List<Pedestrian> pedestrians = new List<Pedestrian>();
            List<Passenger> passengers;
            Passenger nearestPassenger = new Passenger();

            Routing path = Routing.GetInstance();
            int countofRemovedCommands = 0;
            int countofCommands = 0;
            bool IsPassengerSearch = true;
            #endregion

            do
            {
                cars = tp.GetCars();
                passengers = tp.GetPassengers();
                messages = tp.GetMessages();

                if (countofRemovedCommands >= countofCommands - 1 || countofCommands == 0)
                {
                    if (IsPassengerSearch)
                    {
                        PassengerSearching passengerSearching = new PassengerSearching();
                        nearestPassenger = passengerSearching.Searching(path, cars, passengers, nearestPassenger);
                        wod.GetNearestPassangerPosition(cars, nearestPassenger);
                        commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY).ToDirections());
                        routePositions = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY).ToPositions();
                        wod.WriteOutCommands(commands);
                        wod.WriteOutRoutePositions(routePositions);
                        IsPassengerSearch = false;
                    }
                    else
                    {
                        wod.GetPathandEndPoint(cars, nearestPassenger);
                        commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.DestinyPosition.PosX, nearestPassenger.DestinyPosition.PosY).ToDirections());
                        routePositions = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY).ToPositions();
                        wod.WriteOutCommands(commands);
                        wod.WriteOutRoutePositions(routePositions);
                        IsPassengerSearch = true;
                    }
                    tp = ResponseSend(tp, commands, p, cars[0].Id);
                    countofRemovedCommands = 0;
                }
                else
                {
                    tp = ResponseSend(tp, commands, p, cars[0].Id);
                    countofRemovedCommands++;
                }
            } while (messages.Count == 0);
            p.Close();
            Console.WriteLine(messages[0]);
            Console.ReadKey();
        }

        private static TickProcessor ResponseSend(TickProcessor tp, List<string> commands, Protocol p, int carID)
        {
            WriteOutData wod = new WriteOutData();
            int tick = tp.GetTick();
            var json = "{\"response_id\":{\"game_id\": " + tp.GetGameId() + ",\"tick\": " + tick + ",\"car_id\": " + carID + "},\"command\": \"" + commands[0] + "\"}";
            string response = wod.Response(p, json);
            tp = new TickProcessor(response);
            commands.RemoveAt(0);
            return tp;
        }
    }
}

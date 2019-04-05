using Coding_Tomorrow_Cup_Qualifier1.Common;
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
        static void Main(string[] args)
        {
            #region Declarations
            Protocol p = new Protocol();
            FirstMessage fm = FirstMessage.Firstmessage();
            TickProcessor tp = new TickProcessor(p.FirstMessageSender(fm));

            WriteOutData wod = new WriteOutData();
            List<string> messages;
            List<string> commands = new List<string>();

            List<Car> cars;
            List<Pedestrian> pedestrians = new List<Pedestrian>();
            List<Passenger> passengers;
            Passenger nearestPassenger = new Passenger();
            Routing path = Routing.GetInstance();
            List<Pos> routePositions = new List<Pos>();
            int gameid;
            int tick;
            int countofRemovedCommands = 0;
            int countofCommands = 0;
            bool IsPassengerSearch = true;
            #endregion

            do
            {
                gameid = tp.GetGameId();
                tick = tp.GetTick();
                cars = tp.GetCars();
                passengers = tp.GetPassengers();
                messages = tp.GetMessages();

                Console.WriteLine(tick);

                if (countofRemovedCommands >= countofCommands - 1 || countofCommands == 0)
                {
                    wod.WriteOutMessages(messages);

                    if (IsPassengerSearch)
                    {
                        PassengerSearching passengerSearching = new PassengerSearching();
                        nearestPassenger = passengerSearching.Searching(path, cars, passengers, nearestPassenger);
                        wod.GetNearestPassangerPosition(cars, nearestPassenger);

                        commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY).ToDirections());
                        routePositions = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY).ToPositions();

                        countofCommands = commands.Count();

                        wod.WriteOutCommands(commands);
                        wod.WriteOutRoutePositions(routePositions);

                        IsPassengerSearch = false;
                    }
                    else
                    {
                        wod.GetPathandEndPoint(cars, nearestPassenger);

                        commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.DestinyPosition.PosX, nearestPassenger.DestinyPosition.PosY).ToDirections());
                        routePositions = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY).ToPositions();

                        countofCommands = commands.Count();

                        wod.WriteOutCommands(commands);
                        wod.WriteOutRoutePositions(routePositions);

                        IsPassengerSearch = true;
                    }

                    var json = "{\"response_id\":{\"game_id\": " + gameid + ",\"tick\": " + tick + ",\"car_id\": " + cars[0].Id + "},\"command\": \"" + commands[0] + "\"}";

                    string response = wod.Response(p, fm, tp, json);
                    tp = new TickProcessor(response);
                    commands.RemoveAt(0);
                    countofRemovedCommands = 0;
                }
                else
                {
                    var json = "{\"response_id\":{\"game_id\": " + gameid + ",\"tick\": " + tick + ",\"car_id\": " + cars[0].Id + "},\"command\": \"" + commands[0] + "\"}";

                    string response = wod.Response(p, fm, tp, json);
                    tp = new TickProcessor(response);
                    commands.RemoveAt(0);
                    countofRemovedCommands++;
                }
            } while (messages.Count == 0);

            p.Close();

            Console.ReadKey();
        }
    }
}

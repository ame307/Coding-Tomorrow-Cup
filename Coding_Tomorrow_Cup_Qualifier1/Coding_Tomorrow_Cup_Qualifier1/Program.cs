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
        static WriteOutData wod = new WriteOutData();
        static void Main(string[] args)
        {
            #region Declarations
            Protocol p = new Protocol();
            FirstMessage fm = FirstMessage.Firstmessage();
            TickProcessor tp = new TickProcessor(p.FirstMessageSender(fm));
            TickProcessor newTp;


            List<string> messages;

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
            string command = "";
            #endregion

            do
            {
                gameid = tp.GetGameId();
                tick = tp.GetTick();
                cars = tp.GetCars();
                pedestrians = tp.GetPedestrians();
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
                        //path.ChangeMap(cars, pedestrians);
                        command = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY, cars[0]).ToCommand();
                        routePositions = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY, cars[0]).ToPositions();
                        wod.WriteOutCommands(command);
                        wod.WriteOutRoutePositions(routePositions);

                        IsPassengerSearch = false;
                    }
                    else
                    {
                        wod.GetPathandEndPoint(cars, nearestPassenger);
                        command = (path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.DestinyPosition.PosX, nearestPassenger.DestinyPosition.PosY, cars[0]).ToCommand());
                        routePositions = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassenger.Position.PosX, nearestPassenger.Position.PosY, cars[0]).ToPositions();
                        wod.WriteOutCommands(command);
                        wod.WriteOutRoutePositions(routePositions);

                        IsPassengerSearch = true;
                    }
                    var json = "{\"response_id\":{\"game_id\": " + gameid + ",\"tick\": " + tick + ",\"car_id\": " + cars[0].Id + "},\"command\": \"" + command + "\"}";
                    string responseStr = wod.Response(p, json);
                    tp = new TickProcessor(responseStr);
                }
                else
                {
                    var json = "{\"response_id\":{\"game_id\": " + gameid + ",\"tick\": " + tick + ",\"car_id\": " + cars[0].Id + "},\"command\": \"" + command + "\"}";
                    string responseStr = wod.Response(p, json);
                    tp = new TickProcessor(responseStr);
                }
            } while (messages.Count == 0);
            p.Close();
            Console.ReadKey();
        }
    }
}

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
            Protocol p = new Protocol();
            FirstMessage fm = FirstMessage.Firstmessage();
            TickProcessor tp = new TickProcessor(p.FirstMessageSender(fm));

            int gameid;
            int tick = tp.GetTick();


            List<Car> cars = new List<Car>();
            List<Pedestrian> pedestrians = new List<Pedestrian>();
            List<Passenger> passengers = new List<Passenger>();
            List<string> messages = new List<string>();
            Routing path = Routing.GetInstance();
            List<string> commands = new List<string>();
            List<Pos> commands2 = new List<Pos>();
            List<string> responses = new List<string>();

            int y=0;
            int n = 0;
            bool IsPassangerSearch = true;
            Passenger nearestPassanger = new Passenger();

            while (p.GetNs().CanRead && p.GetNs().CanWrite)
            {

                gameid = tp.GetGameId();
                tick = tp.GetTick();
                cars = tp.GetCars();
                pedestrians = tp.GetPedestrians();
                passengers = tp.GetPassengers();
                messages = tp.GetMessages();

                Console.WriteLine(tick);

                if (y >= n-1 || n == 0)
                {
                    for (int i = 0; i < messages.Count; i++)
                    {
                        Console.WriteLine(messages[i]);
                    }

                    if (IsPassangerSearch)
                    {

                        Console.WriteLine("-------Utas keresése--------");


                        int nearestPassangerDistance = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, passengers[0].Position.PosX, passengers[0].Position.PosY).ToPositions().Count;
                        nearestPassanger = passengers[0];
                        for (int i = 1; i < passengers.Count; i++)
                        {
                            int passangerDistance = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, passengers[i].Position.PosX, passengers[i].Position.PosY).ToPositions().Count;
                            if (nearestPassangerDistance > passangerDistance)
                            {
                                nearestPassanger = passengers[i];
                            }
                        }

                        Console.WriteLine("Kocsi induló pozíció: ({0};{1})", cars[0].Position.PosX, cars[0].Position.PosY);
                        Console.WriteLine("Kocsi iránya: {0}", cars[0].Direction);
                        Console.WriteLine("Legközelebbi utas:\nId:{0}\nPosition: ({1};{2})\nDestiny position: ({3};{4})", nearestPassanger.Id, nearestPassanger.Position.PosX, nearestPassanger.Position.PosY, nearestPassanger.DestinyPosition.PosX, nearestPassanger.DestinyPosition.PosY);

                        commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassanger.Position.PosX, nearestPassanger.Position.PosY).ToDirections());

                        commands2 = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassanger.Position.PosX, nearestPassanger.Position.PosY).ToPositions();

                        n = commands.Count();

                        Console.WriteLine("\n\nÚtvonal utasítások:");               
                        for (int i = 0; i < commands.Count; i++)
                        {
                            Console.WriteLine(commands[i]);
                        }
                        Console.WriteLine("\n\nÚtvonal pozíciók:");
                        for (int i = 0; i < commands2.Count; i++)
                        {
                            Console.WriteLine("({0};{1})",commands2[i].PosX, commands2[i].PosY);
                        }


                        IsPassangerSearch = false;
                    }
                    else
                    {
                        Console.WriteLine("-------Útvonal keresése--------");
                        Console.WriteLine("Kocsi induló pozíció: ({0};{1})", cars[0].Position.PosX, cars[0].Position.PosY);
                        Console.WriteLine("Végpont: ({0};{1})", nearestPassanger.DestinyPosition.PosX, nearestPassanger.DestinyPosition.PosY);
                        commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassanger.DestinyPosition.PosX, nearestPassanger.DestinyPosition.PosY).ToDirections());
                        commands2 = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, nearestPassanger.Position.PosX, nearestPassanger.Position.PosY).ToPositions();

                        n = commands.Count();

                        Console.WriteLine("\n\nÚtvonal utasítások:");
                        for (int i = 0; i < commands.Count; i++)
                        {
                            Console.WriteLine(commands[i]);
                        }
                        Console.WriteLine("\n\nÚtvonal pozíciók:");
                        for (int i = 0; i < commands2.Count; i++)
                        {
                            Console.WriteLine("({0};{1})", commands2[i].PosX, commands2[i].PosY);
                        }

                        IsPassangerSearch = true;
                    }
                
                    var json = "{\"response_id\":{\"game_id\": " + gameid + ",\"tick\": " + tick + ",\"car_id\": " + cars[0].Id + "},\"command\": \""+ commands[0] +"\"}";

                    Console.WriteLine("Elküldött parancs: {0}", json);
                    string response = p.MessageSender(json);
                    Console.WriteLine("Szerver válasza: {0}",response);
                    tp = new TickProcessor(response);
                    commands.RemoveAt(0);
                    y = 0;                   
                }
                else
                {
                    var json = "{\"response_id\":{\"game_id\": " + gameid + ",\"tick\": " + tick + ",\"car_id\": " + cars[0].Id + "},\"command\": \"" + commands[0] + "\"}";

                    Console.WriteLine("Elküldött parancs: {0}", json);
                    string response = p.MessageSender(json);
                    Console.WriteLine("Szerver válasza: {0}", response);
                    tp = new TickProcessor(response);
                    commands.RemoveAt(0);
                    y++;
                } 
                
            }
            p.Close();
            

            /*
            Car kocsi = new Car(0, new Pos(57, 58), 100, 0, "UP", "NO_OP", 0);
            Pos utasPos = new Pos(27, 57);
            Pos desPos = new Pos(55, 20);

            Console.WriteLine("--Adatok--");
            Console.WriteLine("Kocsi: {0}:{1}", kocsi.Position.PosX, kocsi.Position.PosY);
            Console.WriteLine("Kocsi irány: {0}", kocsi.Direction);
            Console.WriteLine("Utas: {0}:{1}", utasPos.PosX, utasPos.PosY);

            Routing path = Routing.GetInstance();
            List<Pos> positions = path.FindRoute(kocsi.Position.PosX, kocsi.Position.PosY, utasPos.PosX, utasPos.PosY).ToPositions();
            Console.WriteLine("--Út koordináták--");
            for (int i = 0; i < positions.Count; i++)
            {
                Console.WriteLine(positions[i].PosX + ":" + positions[i].PosY);
            }

            List<string> directions = path.FindRoute(kocsi.Position.PosX, kocsi.Position.PosY, utasPos.PosX, utasPos.PosY).ToDirections();
            Console.WriteLine("--Irányok--");
            for (int i = 0; i < directions.Count; i++)
            {
                Console.WriteLine(directions[i]);
            }

            List<string> commands = kocsi.CreateCommands(directions);
            Console.WriteLine("--Utasítások--");

            for (int i = 0; i < commands.Count; i++)
            {
                Console.WriteLine(commands[i]);
            }*/

            Console.ReadKey();

        }
    }
}

﻿using Newtonsoft.Json;
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
            List<string> responses = new List<string>();

            int y=0;
            bool IsPassangerSearch = true;
            Passenger nearestPassanger = new Passenger();

            while (tick < 1000)
            {

                gameid = tp.GetGameId();
                cars = tp.GetCars();
                pedestrians = tp.GetPedestrians();
                passengers = tp.GetPassengers();
                messages = tp.GetMessages();

                Console.WriteLine(tick);

                if (y >= commands.Count || commands.Count == 0)
                {
                    for (int i = 0; i < messages.Count; i++)
                    {
                        Console.WriteLine(messages[i]);
                    }

                    if (IsPassangerSearch)
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

                        IsPassangerSearch = false;
                    }
                    else
                    {
                        commands = cars[0].CreateCommands(path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosX, nearestPassanger.DestinyPosition.PosX, nearestPassanger.DestinyPosition.PosY).ToDirections());
                    }
                
                    var json = "{\"response_id\":{\"game_id\": " + gameid + ",\"tick\": " + tick + ",\"car_id\": " + cars[0].Id + "},\"command\": \""+ commands[0] +"\"}";
                    p.MessageSender(json);
                    commands.RemoveAt(0);
                    y = 0;
                    tick++;
                   
                }
                else
                {
                    var json = "{\"response_id\":{\"game_id\": " + gameid + ",\"tick\": " + tick + ",\"car_id\": " + cars[0].Id + "},\"command\": \"" + commands[0] + "\"}";
                    p.MessageSender(json);
                    commands.RemoveAt(0);
                    y++;
                    tick++;
                } 
                
            }

            p.Close();
            Console.ReadKey();

        }
    }
}

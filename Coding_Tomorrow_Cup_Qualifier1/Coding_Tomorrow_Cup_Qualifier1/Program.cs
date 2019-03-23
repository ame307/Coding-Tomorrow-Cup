﻿using System;
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

            //Test
            TickProcessor tp = new TickProcessor(Path.Combine(Path.GetFullPath(@"..\..\"), "Resources/TickExample.json"));

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
            }

            List<Pos> loc = Routing.GetInstance().FindRoute(28,59,28,55).ToPositions();

            for(int i=0;i<loc.Count;i++)
            {
                Console.WriteLine(loc[i].PosX + " " + loc [i].PosY);
            }
           

            Console.ReadKey();
        }
    }
}

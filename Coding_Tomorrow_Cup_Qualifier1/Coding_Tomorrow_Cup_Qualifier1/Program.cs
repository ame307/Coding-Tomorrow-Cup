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

            //Test
            TickProcessor tp = new TickProcessor(Path.Combine(Path.GetFullPath(@"..\..\"), "Resources/TickExample.json"));

            Console.WriteLine(tp.GetGameId());
            Console.WriteLine(tp.GetTick());
            Console.WriteLine(tp.GetCarId());

            Car[] cars = tp.GetCars();
            Pedestrian[] pedestrians = tp.GetPedestrians();
            Passenger[] passengers = tp.GetPassengers();

            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine(cars[i].Id);
                Console.WriteLine(cars[i].Position);
                Console.WriteLine(cars[i].Life);
                Console.WriteLine(cars[i].Speed);
                Console.WriteLine(cars[i].Direction);
                Console.WriteLine(cars[i].NextCommand);
                Console.WriteLine(cars[i].TransportedPedestrians);
                Console.WriteLine(cars[i].PassengerId);
            }

            for (int i = 0; i < pedestrians.Length; i++)
            {
                Console.WriteLine(pedestrians[i].Id);
                Console.WriteLine(pedestrians[i].Position);
                Console.WriteLine(pedestrians[i].Speed);
                Console.WriteLine(pedestrians[i].Direction);
                Console.WriteLine(pedestrians[i].NextCommand);
        
            }

            for (int i = 0; i < passengers.Length; i++)
            {
                Console.WriteLine(passengers[i].Id);
                Console.WriteLine(passengers[i].Position);
                Console.WriteLine(passengers[i].DestinyPosition);
                Console.WriteLine(passengers[i].CarId);
            }

        
            Console.ReadKey();
        }
    }
}

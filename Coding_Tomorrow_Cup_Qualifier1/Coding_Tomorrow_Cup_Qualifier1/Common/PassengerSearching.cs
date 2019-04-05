using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1.Common
{
    class PassengerSearching
    {
        public Passenger Searching(Routing path, List<Car> cars, List<Passenger> passengers, Passenger nearestPassenger)
        {
            Console.WriteLine("-------Utas keresése--------");
            int nearestPassangerDistance = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, passengers[0].Position.PosX, passengers[0].Position.PosY, cars[0]).ToPositions().Count;
            nearestPassenger = passengers[0];
            for (int i = 1; i < passengers.Count; i++)
            {
                int passangerDistance = path.FindRoute(cars[0].Position.PosX, cars[0].Position.PosY, passengers[i].Position.PosX, passengers[i].Position.PosY, cars[0]).ToPositions().Count;
                if (nearestPassangerDistance > passangerDistance)
                {
                    nearestPassenger = passengers[i];
                }
            }
            return nearestPassenger;
        }
    }
}

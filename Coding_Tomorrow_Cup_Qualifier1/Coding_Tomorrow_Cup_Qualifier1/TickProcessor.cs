using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class TickProcessor
    {
        public JObject Tick { get; set; }
                
        public TickProcessor(string path)
        {
            StreamReader sr = System.IO.File.OpenText(path);
            string json = sr.ReadToEnd();
            Tick = JObject.Parse(json);

        }

        public int GetGameId()
        {
            JObject requestId = ((JObject)Tick["request_id"]);
            return (int)requestId["game_id"];
        }

        public int GetTick()
        {
            JObject requestId = ((JObject)Tick["request_id"]);
            return (int)requestId["tick"];
        }

        public int GetCarId()
        {
            JObject requestId = ((JObject)Tick["request_id"]);
            return (int)requestId["car_id"];
        }

        public Car[] GetCars()
        {
            JArray jsonCars = (JArray)Tick["cars"];
            Car[] cars = new Car[jsonCars.Count];

            for (int i=0;i<jsonCars.Count;i++)
            {
                Car temp = new Car((int)jsonCars[i]["id"], new Pos().FromString((string)jsonCars[i]["pos"]), (int)jsonCars[i]["life"],
                (int)jsonCars[i]["speed"], (string)jsonCars[i]["direction"], (string)jsonCars[i]["next_command"],
                (int)jsonCars[i]["transported"], (int)jsonCars[i]["passenger_id"]);

                cars[i] = temp;                
            }

            return cars;
        }

        public Pedestrian[] GetPedestrians()
        {
            JArray jsonPedestrians = (JArray)Tick["pedestrians"];
            Pedestrian[] pedestrians = new Pedestrian[jsonPedestrians.Count];

            for (int i = 0; i < jsonPedestrians.Count; i++)
            {
                Pedestrian temp = new Pedestrian((int)jsonPedestrians[i]["id"], new Pos().FromString((string)jsonPedestrians[i]["pos"]), (int)jsonPedestrians[i]["speed"],
                (string)jsonPedestrians[i]["direction"], (string)jsonPedestrians[i]["next_command"]);

                pedestrians[i] = temp;
            }

            return pedestrians;
        }

        public Passenger[] GetPassengers()
        {
            JArray jsonPassengers = (JArray)Tick["passengers"];
            Passenger[] passengers = new Passenger[jsonPassengers.Count];

            for (int i = 0; i < jsonPassengers.Count; i++)
            {
                Passenger temp = new Passenger((int)jsonPassengers[i]["id"], new Pos().FromString((string)jsonPassengers[i]["pos"]),
                new Pos().FromString((string)jsonPassengers[i]["dest_pos"]), (int)jsonPassengers[i]["car_id"]);

                passengers[i] = temp;
            }

            return passengers;
        }

       
    }
}

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
    public class TickProcessor
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
                Car temp = new Car((int)jsonCars[i]["id"], new Pos((int)jsonCars[i]["pos"]["x"], (int)jsonCars[i]["pos"]["y"]), (int)jsonCars[i]["life"],
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
                Pedestrian temp = new Pedestrian((int)jsonPedestrians[i]["id"], new Pos((int)jsonPedestrians[i]["pos"]["x"], (int)jsonPedestrians[i]["pos"]["y"]), (int)jsonPedestrians[i]["speed"],
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
                Passenger temp = new Passenger((int)jsonPassengers[i]["id"], new Pos((int)jsonPassengers[i]["pos"]["x"], (int)jsonPassengers[i]["pos"]["y"]),
                new Pos((int)jsonPassengers[i]["dest_pos"]["x"], (int)jsonPassengers[i]["dest_pos"]["y"]), (int)jsonPassengers[i]["car_id"]);

                passengers[i] = temp;
            }

            return passengers;
        }

        public string[] GetMessages() 
        {
            JArray jsonMessages = (JArray)Tick["messages"];
            string[] messages = new string[jsonMessages.Count];

            for (int i = 0; i < jsonMessages.Count; i++)
            {
                messages[i] = jsonMessages[i].ToString();
            }

            return messages;
        }
       
    }
}

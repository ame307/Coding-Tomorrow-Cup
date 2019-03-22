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
    class DeserializeTick
    {
        public DeserializeTick()
        {
            StreamReader file = File.OpenText(Path.Combine(Path.GetFullPath(@"..\..\"), "Resources/TickExample.json"));
            string json = file.ReadToEnd();
            JObject tick = JObject.Parse(json);
            JObject request_id = (JObject)tick["request_id"];
            JObject cars = (JObject)((JArray)tick["cars"])[0];
            JObject pos = (JObject)cars["Pos"];
            Car car = new Car((int)cars["id"], carPosition, (int)cars["life"],
                (int)cars["speed"], (string)cars["direction"], (string)cars["next_command"],
                (int)cars["transported"], (int)cars["passenger_id"]);
        }
    }
}

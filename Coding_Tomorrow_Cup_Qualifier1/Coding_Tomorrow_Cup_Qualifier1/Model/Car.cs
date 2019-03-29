using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    public class Car
    {

        public int Id { get; set; }
        public Pos Position { get; set; }
        public int Life { get; set; }
        public int Speed { get; set; }
        public string Direction { get; set; }
        public string NextCommand { get; set; }
        public int TransportedPedestrians { get; set; }
        public int PassengerId { get; set; }

        public Car(int id, Pos position, int life, int speed, string direction, string nextcommand, int transportedPredestrians, int passengerId)
        {
            Id = id;
            Position = position;
            Life = life;
            Speed = speed;
            Direction = direction;
            NextCommand = nextcommand;
            TransportedPedestrians = transportedPredestrians;
            PassengerId = passengerId;
        }

        public List<string> CreateCommands(List<string> directions)
        {
            List<string> commands = new List<string>();
            directions = CountForwards(directions);

            string direction="";

            switch (this.Direction)
            {
                case "^": direction = global::Direction.NORTH.ToString(); break;
                case "v": direction = global::Direction.SOUTH.ToString(); break;
                case "<": direction = global::Direction.WEST.ToString(); break;
                case ">": direction = global::Direction.EAST.ToString(); break;
            }

            if (direction == "SOUTH" && directions[0] == "NORTH" ||
                direction == "NORTH" && directions[0] == "SOUTH" ||
                direction == "EAST" && directions[0] == "WEST" ||
                direction == "WEST" && directions[0] == "EAST")
            {
                commands.Add("CAR_INDEX_LEFT");
                commands.Add("CAR_INDEX_LEFT");
            }
            else if (direction == "SOUTH" && directions[0] == "WEST" ||
                     direction == "WEST" && directions[0] == "NORTH" ||
                     direction == "NORTH" && directions[0] == "EAST" ||
                     direction == "EAST" && directions[0] == "SOUTH")
            {
                commands.Add("CAR_INDEX_RIGHT");
            }
            else if (direction == "SOUTH" && directions[0] == "EAST" ||
                     direction == "EAST" && directions[0] == "NORTH" ||
                     direction == "NORTH" && directions[0] == "WEST" ||
                     direction == "WEST" && directions[0] == "SOUTH")
            {
                commands.Add("CAR_INDEX_LEFT");
            }

            if(this.Speed == 0)
            {
                commands.Add("ACCELERATION");
            }

            for (int i = 0; i < directions.Count - 1; i++)
            {
                if (directions[i + 1] == "LEFT")
                {
                    commands.Add("CAR_INDEX_LEFT");
                }
                else if (directions[i + 1] == "RIGHT")
                {
                    commands.Add("CAR_INDEX_RIGHT");
                }
                else
                {
                    if (directions.Count > i + 2)
                    {
                        for (int j = 0; j < Convert.ToInt32(directions[i + 1]) - 1; j++)
                        {
                            commands.Add("NO_OP");
                        }
                    }
                    else
                    {
                        commands.Add("DECELERATION");
                    }
                }
            }

            return commands;
        }

        private List<string> CountForwards(List<string> directions)
        {
            List<string> temp = new List<string>();
            int c;

            for (int i = 0; i < directions.Count; i++)
            {
                if (directions[i] == "FORWARD")
                {
                    c = 0;
                    while (i < directions.Count && directions[i] == "FORWARD")
                    {
                        c++;
                        i++;
                    }

                    temp.Add(c.ToString());
                }

                if(i< directions.Count)
                {
                    temp.Add(directions[i]);
                }
            }

            return temp;

        }
    }
}

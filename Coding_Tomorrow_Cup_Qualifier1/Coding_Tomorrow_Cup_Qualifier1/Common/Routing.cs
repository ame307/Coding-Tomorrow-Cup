using Coding_Tomorrow_Cup_Qualifier1.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class Routing
    {   
        private static Routing instance;
        public static Routing GetInstance()
        {
            if (instance == null)
            {
                instance = new Routing();
            }

            return instance;
        }

        private static string[] defaultmap = new string[]
            {
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "PPSSPPPZZPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPZZPPPSSPP",
                "GPSSPGPSSPGBBGBBGGBBGGBBGBBGPSSPGBBGBBGGBBGGBBGBBGPSSPBPSSPG",
                "GPSSPBPSSPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPBPSSPG",
                "GPSSPBPSSPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPGPSSSPPGBBPSSPGGGGGBBBBBGPPPPPPPPGGBBBBBBGBBPSSSPGPSSPG",
                "GPSSPBPSSSSPPGBPSSPGTGPPPPPPPPPSSSSSSPPPBBBBBBGBBPSGSPBPSSPG",
                "GPSSPBPPSSSSPPGPSSPGGGPSSSSSSSSSSSSSSSSPPPGGGPPPPPSGSPBPSSPG",
                "GPSSPGGPPSSSSPPPSSPPBBPSSSSSSSSSSPPSSSSSSPPPGPSSSSSGSPGPSSPG",
                "GPSSPGGGPPSSSSPSSSSPPPPSSPSSPPSSPPPPPSSSSSSPPPSSSSSSSPGPSSPG",
                "GPSSPGGGGPPSSSSSBBSSSSSSSSSSPPSSSSSSPPPSSSSSSZSSPPPPPPGPSSPG",
                "GPSSPGGGGGPPSSSSBBSSSSSSSSSSPPSPPPPSSSPPPSSSSZSSPPSSPGGPSSPG",
                "GPSSPGGGGGGPPPPSSSSPPPPPPPPPPPSPPSSSSSSPPPPPPPSSPPSSPTTPSSPG",
                "GPSSPGGGGGGGGGPPSSPPSSSSSSSSGPSSSSPPSSSSPPGTGPSSSSSSPTGPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSSSSSSSSPPPPPPPPSSSSPPGPPSSSSSSPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSPPPPSSSSSSSSSSPPSSSSPPPSSSPPPPPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSPPPPPGGPPSSSSSSSSSSPPSSSSPSSSSPBBBBTGPSSPG",
                "GPSSPGPPPPPPPPPPSSPGGGGGGGPPPPPPPPSSSSPPSSSSSSSPPBBBBBGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGGGGGGGGBBGPPSSSSPPSSSSSPPGGGGGGGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGBGGGGGGBBGGPPSSSSPPPPSSSPPPPPPGTPSSPG",
                "GPSSPGPSSPPPPPPPSSPGGGGGGGGGGGGGGGGPPSSSSSSPSSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGGPPPPGGGPPSSSSSPPSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGPPSSPPGGGPPPPPPPPPPPPPZZPPGPSSPG",
                "GPZZPPPZZPPPPPPPSSPPPPPPPPPPPSSSSPPPPPPPPPPPPPPPPSSSSPPPZZPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPZZPPPPPPPPPPPPPPPPSSPPPPPPPSSSSPPPPPPPSSPPPPPPPSSSSPPPZZPG",
                "GPSSPGPSSSSPPBBBBPPSSSPGGPPPPPSSPPPPPGGPSSSPPGBBPPSSPPGPSSPG",
                "GPSSPBPSSSSSPBBBBPSSSSPBBPSSSSSSSSSSPGGPSSSSPGBBGPSSPGBPSSPG",
                "GPSSPBPPPSSSPGGGGPSSSPPGGPSSSSSSSSSSPGGPPSSSPGGGGPSSPGBPSSPG",
                "GPSSPGGGPPSSPGGGGPSSPPGGGPSSPPPPPPSSPGGGPPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGGGBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGBBBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGPPPPSSPPPPPPZZPPPPPPZZPPPPPPSSPPPPPPZZPPPPPPZZPPGPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPGPSSPPPPPSSPPPPPPPPPPPPZZPPPPPZZPPPPPSSPPPPPSSPPPBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPGPSSPPPPPZZPPPPPPPPPPPPSSPPPPPSSPPPPPSSPPPPPSSPPGGPSSPG",
                "GPSSPGPSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGBPSSPG",
                "GPSSPGPSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGBPSSPG",
                "GPSSPGPPSSPPPPZZPPPPSSPPPPZZPPPPSSPPPPPPPPPPSSPPPPZZPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPGBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPBBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPPPPSSPPPPZZPPPPSSPPPPZZPPPPPPPPPPZZPPPPSSPGGPSSPG",
                "GPSSPGGPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPPPGGPSSPG",
                "GPSSPGGPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGGGGPSSPG",
                "GPSSPGGPPPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPGGGGPSSPG",
                "GPSSPGGGGGGGGGGGGGBBBBGGBBBBPSSPBBBBGGBBBBGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSSS",
                "SSSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSSS",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG"
            };
        public string[] map = defaultmap;
        public string[] Map
        {
            get { return map; }
            set { map = value; }
        }

        private List<Location> route;
        private Car car;

        public Routing FindRoute(int StartX, int StartY, int TargetX, int TargetY, Car car)
        {
            this.car = car;
            Location current = null;
            var start = new Location { X = StartX, Y = StartY };
            var target = new Location { X = TargetX, Y = TargetY };
            var openList = new List<Location>();
            var closedList = new List<Location>();
            int currentDistanceFromStart = 0;

            route = new List<Location>();
            target = CheckRoad(target.X, target.Y, map);

            openList.Add(start);

            while (openList.Count > 0)
            {
                var lowest = openList.Min(l => l.distanceScore);
                current = openList.First(l => l.distanceScore == lowest);
                closedList.Add(current);
                openList.Remove(current);

                if (closedList.FirstOrDefault(l => l.X == target.X && l.Y == target.Y) != null)
                    break;

                var adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, map, current);
                currentDistanceFromStart++;

                foreach (var adjacentSquare in adjacentSquares)
                {
                    if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) != null)
                        continue;

                    if (openList.FirstOrDefault(l => l.X == adjacentSquare.X && l.Y == adjacentSquare.Y) == null)
                    {
                        adjacentSquare.distanceFromStart = currentDistanceFromStart;
                        adjacentSquare.distanceFromTarget = ComputeEndDistance(adjacentSquare.X, adjacentSquare.Y, target.X, target.Y);
                        adjacentSquare.distanceScore = adjacentSquare.distanceFromStart + adjacentSquare.distanceFromTarget;
                        adjacentSquare.previousLocation = current;
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        if (currentDistanceFromStart + adjacentSquare.distanceFromTarget > adjacentSquare.distanceScore)
                        {
                            adjacentSquare.distanceFromStart = currentDistanceFromStart;
                            adjacentSquare.distanceScore = adjacentSquare.distanceFromStart + adjacentSquare.distanceFromTarget;
                            adjacentSquare.previousLocation = current;
                        }
                    }
                }
            }

            while (current != null)
            {
                route.Add(new Location { X = current.X, Y = current.Y });
                current = current.previousLocation;
            }

            route.Reverse();
            return this;
        }

        private List<Location> GetWalkableAdjacentSquares(int x, int y, string[] map, Location current)
        {
            var proposedLocations = new List<Location>()
            {
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
            };

            if (proposedLocations[0].Y == -1)
                proposedLocations[0] = new Location { X = x, Y = 59 };
            if (proposedLocations[1].Y == 60)
                proposedLocations[1] = new Location { X = x, Y = 0 };
            if (proposedLocations[2].X == -1)
                proposedLocations[2] = new Location { X = 59, Y = y };
            if (proposedLocations[3].X == 60)
                proposedLocations[3] = new Location { X = 0, Y = y };
            if(current.distanceFromTarget < 3)
                return proposedLocations.Where(l => map[l.Y][l.X] == 'S' || map[l.Y][l.X] == 'Z' || map[l.Y][l.X] == 'P').ToList();
            else
                return proposedLocations.Where(l => map[l.Y][l.X] == 'S' || map[l.Y][l.X] == 'Z').ToList();
        }

        private Location CheckRoad(int x, int y, string[] map)
        {
            var proposedLocations = new List<Location>()
            {
                new Location { X = x, Y = y },
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
                
            };

            if (proposedLocations[1].Y == -1)
                proposedLocations[1] = new Location { X = x, Y = 59 };
            if (proposedLocations[2].Y == 60)
                proposedLocations[2] = new Location { X = x, Y = 0 };
            if (proposedLocations[3].X == -1)
                proposedLocations[3] = new Location { X = 59, Y = y };
            if (proposedLocations[4].X == 60)
                proposedLocations[4] = new Location { X = 0, Y = y };
            
            return proposedLocations.Where(l => map[l.Y][l.X] == 'S' || map[l.Y][l.X] == 'Z' || map[l.Y][l.X] == 'P').ToList()[0];
        }

        static int ComputeEndDistance(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }

        public List<Pos> ToPositions()
        {
            List<Pos> positions = new List<Pos>();
            for (int i = 0; i < route.Count; i++)            
                positions.Add(new Pos(route[i].X, route[i].Y));            
            return positions;
        }

        public List<string> ToCommands()
        {
            List<string> directions = new List<string>();
            Direction direction = new Direction();

            if(route.Count == 1){}
            else if (route[0].X - route[1].X == 0)
                direction = route[0].Y < route[1].Y ? Direction.SOUTH : Direction.NORTH;
            else
                direction = route[0].X < route[1].X ? Direction.EAST : Direction.WEST;
            directions.Add(direction.ToString());

            int i = 1;
            while (i < route.Count)
            {
                if (route[i - 1].X != route[i].X && (direction == Direction.NORTH || direction == Direction.SOUTH))
                {
                    if (route[i - 1].X < route[i].X)
                    {
                        directions.Add(direction == Direction.SOUTH ? "LEFT" : "RIGHT");
                        direction = Direction.EAST;
                    }
                    else
                    {
                        directions.Add(direction == Direction.NORTH ? "LEFT" : "RIGHT");
                        direction = Direction.WEST;
                    }
                }
                else if (route[i - 1].Y != route[i].Y && (direction == Direction.WEST || direction == Direction.EAST))
                {
                    if (route[i - 1].Y < route[i].Y)
                    {
                        directions.Add(direction == Direction.EAST ? "RIGHT" : "LEFT");
                        direction = Direction.SOUTH;
                    }
                    else
                    {
                        directions.Add(direction == Direction.WEST ? "RIGHT" : "LEFT");
                        direction = Direction.NORTH;
                    }
                }
                else
                {
                    directions.Add("FORWARD");
                    i++;
                }
            }
            return CreateCommands(directions);
        }

        private List<string> CreateCommands(List<string> directions)
        {
            List<string> commands = new List<string>();
            directions = CountForwards(directions);
            string direction = "";

            switch (this.car.Direction)
            {
                case "UP": direction = global::Direction.NORTH.ToString(); break;
                case "DOWN": direction = global::Direction.SOUTH.ToString(); break;
                case "LEFT": direction = global::Direction.WEST.ToString(); break;
                case "RIGHT": direction = global::Direction.EAST.ToString(); break;
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
            commands.Add("ACCELERATION");

            int speed = 1;
            for (int i = 0; i < directions.Count - 1; i++)
            {
                if (directions[i + 1] == "LEFT")
                {
                    commands.Add("DECELERATION");
                    commands.Add("CAR_INDEX_LEFT");
                    commands.Add("ACCELERATION");
                }
                else if (directions[i + 1] == "RIGHT")
                {
                    commands.Add("DECELERATION");
                    commands.Add("CAR_INDEX_RIGHT");
                    commands.Add("ACCELERATION");
                }
                else
                {
                    if (directions.Count > i + 1)
                    {
                        int n = Convert.ToInt32(directions[i + 1]);
                        if (n <= 4)
                        {
                            for (int j = 0; j < n - 1; j++)
                            {
                                commands.Add("NO_OP");
                            }
                        }
                        else if (n > 4 && n <= 13)
                        {
                            commands.Add("ACCELERATION");
                            speed = 2;
                            for (int j = 0; j < ((n - 4) / 2); j++)
                            {
                                commands.Add("NO_OP");
                            }
                            commands.Add("DECELERATION");
                            if (((Convert.ToInt32(directions[i + 1]) - 4) % 2) == 1)
                            {
                                commands.Add("NO_OP");
                            }
                        }
                        else if (n > 13)
                        {
                            commands.Add("ACCELERATION");
                            commands.Add("ACCELERATION");
                            speed = 3;

                            int x = n - 14;
                            for (int j = 0; j < (x / 3) + 1; j++)
                            {
                                commands.Add("NO_OP");
                            }

                            if (x % 3 == 0)
                            {
                                commands.Add("DECELERATION");
                                commands.Add("DECELERATION");
                                commands.Add("NO_OP");
                                commands.Add("NO_OP");
                            }
                            else if (x % 3 == 1)
                            {
                                commands.Add("DECELERATION");
                                commands.Add("NO_OP");
                                commands.Add("DECELERATION");
                                commands.Add("NO_OP");
                            }
                            else if (x % 3 == 2)
                            {
                                commands.Add("NO_OP");
                                commands.Add("DECELERATION");
                                commands.Add("DECELERATION");
                                commands.Add("NO_OP");
                            }
                        }
                    }
                }
            }

            commands.Add("DECELERATION");

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

                if (i < directions.Count)
                {
                    temp.Add(directions[i]);
                }
            }

            return temp;
        }

        public void ChangeMap(List<Car> cars, List<Pedestrian> pedestrians)
        {
            map = new string[]
            {
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "PPSSPPPZZPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPZZPPPSSPP",
                "GPSSPGPSSPGBBGBBGGBBGGBBGBBGPSSPGBBGBBGGBBGGBBGBBGPSSPBPSSPG",
                "GPSSPBPSSPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPBPSSPG",
                "GPSSPBPSSPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPGPSSSPPGBBPSSPGGGGGBBBBBGPPPPPPPPGGBBBBBBGBBPSSSPGPSSPG",
                "GPSSPBPSSSSPPGBPSSPGTGPPPPPPPPPSSSSSSPPPBBBBBBGBBPSGSPBPSSPG",
                "GPSSPBPPSSSSPPGPSSPGGGPSSSSSSSSSSSSSSSSPPPGGGPPPPPSGSPBPSSPG",
                "GPSSPGGPPSSSSPPPSSPPBBPSSSSSSSSSSPPSSSSSSPPPGPSSSSSGSPGPSSPG",
                "GPSSPGGGPPSSSSPSSSSPPPPSSPSSPPSSPPPPPSSSSSSPPPSSSSSSSPGPSSPG",
                "GPSSPGGGGPPSSSSSBBSSSSSSSSSSPPSSSSSSPPPSSSSSSZSSPPPPPPGPSSPG",
                "GPSSPGGGGGPPSSSSBBSSSSSSSSSSPPSPPPPSSSPPPSSSSZSSPPSSPGGPSSPG",
                "GPSSPGGGGGGPPPPSSSSPPPPPPPPPPPSPPSSSSSSPPPPPPPSSPPSSPTTPSSPG",
                "GPSSPGGGGGGGGGPPSSPPSSSSSSSSGPSSSSPPSSSSPPGTGPSSSSSSPTGPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSSSSSSSSPPPPPPPPSSSSPPGPPSSSSSSPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSPPPPSSSSSSSSSSPPSSSSPPPSSSPPPPPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSPPPPPGGPPSSSSSSSSSSPPSSSSPSSSSPBBBBTGPSSPG",
                "GPSSPGPPPPPPPPPPSSPGGGGGGGPPPPPPPPSSSSPPSSSSSSSPPBBBBBGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGGGGGGGGBBGPPSSSSPPSSSSSPPGGGGGGGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGBGGGGGGBBGGPPSSSSPPPPSSSPPPPPPGTPSSPG",
                "GPSSPGPSSPPPPPPPSSPGGGGGGGGGGGGGGGGPPSSSSSSPSSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGGPPPPGGGPPSSSSSPPSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGPPSSPPGGGPPPPPPPPPPPPPZZPPGPSSPG",
                "GPZZPPPZZPPPPPPPSSPPPPPPPPPPPSSSSPPPPPPPPPPPPPPPPSSSSPPPZZPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPZZPPPPPPPPPPPPPPPPSSPPPPPPPSSSSPPPPPPPSSPPPPPPPSSSSPPPZZPG",
                "GPSSPGPSSSSPPBBBBPPSSSPGGPPPPPSSPPPPPGGPSSSPPGBBPPSSPPGPSSPG",
                "GPSSPBPSSSSSPBBBBPSSSSPBBPSSSSSSSSSSPGGPSSSSPGBBGPSSPGBPSSPG",
                "GPSSPBPPPSSSPGGGGPSSSPPGGPSSSSSSSSSSPGGPPSSSPGGGGPSSPGBPSSPG",
                "GPSSPGGGPPSSPGGGGPSSPPGGGPSSPPPPPPSSPGGGPPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGGGBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGBBBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGPPPPSSPPPPPPZZPPPPPPZZPPPPPPSSPPPPPPZZPPPPPPZZPPGPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPGPSSPPPPPSSPPPPPPPPPPPPZZPPPPPZZPPPPPSSPPPPPSSPPPBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPGPSSPPPPPZZPPPPPPPPPPPPSSPPPPPSSPPPPPSSPPPPPSSPPGGPSSPG",
                "GPSSPGPSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGBPSSPG",
                "GPSSPGPSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGBPSSPG",
                "GPSSPGPPSSPPPPZZPPPPSSPPPPZZPPPPSSPPPPPPPPPPSSPPPPZZPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPGBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPBBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPPPPSSPPPPZZPPPPSSPPPPZZPPPPPPPPPPZZPPPPSSPGGPSSPG",
                "GPSSPGGPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPPPGGPSSPG",
                "GPSSPGGPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGGGGPSSPG",
                "GPSSPGGPPPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPGGGGPSSPG",
                "GPSSPGGGGGGGGGGGGGBBBBGGBBBBPSSPBBBBGGBBBBGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSSS",
                "SSSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSSS",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG"
            };
            foreach (var car in cars)
            {
                int X = car.Position.PosX;
                int Y = car.Position.PosY;
                var line = map[Y].ToCharArray();
                line[X] = 'C';
                map[Y] = line.ToString();
            }
            foreach (var p in pedestrians)
            {
                int X = p.Position.PosX;
                int Y = p.Position.PosY;
                var line = map[Y].ToCharArray();
                line[X] = 'C';
                map[Y] = line.ToString();
            }
        }
    }
}

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

        private Car myCar;

        public Car MyCar
        {
            set { myCar = value; }
        }

        private List<Car> cars;

        public List<Car> Cars
        {
            set { cars = value; }
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
                "GPSSPGPSSSSPGBBPSSPGGGGGBBBBBGPPPPPPPPGGBBBBBBGBBPSSSPGPSSPG",
                "GPSSPBPSSSSSPGBPSSPGTGPSPPPPPPSSSSSSSSSPBBBBBBGBBPSGSPBPSSPG",
                "GPSSPBPSSSSSSPGPSSPGGGPSSSSSSSSSSSSSSSSPSPGGGPPPPPSGSPBPSSPG",
                "GPSSPGGPSSSSSPPPSSPPBBPSSSSSSSSSSPPSSSSSSPSPGPSSSSSGSPGPSSPG",
                "GPSSPGGGPSSSSSSSSSSSPPPSSPSSPPSSPPPPPSSSSSSPPPSSSSSSSSGPSSPG",
                "GPSSPGGGGPSSSSSSBBSSSSSSSSSSPPSSSSSSPPPSSSSSSZSSPPPPPPGPSSPG",
                "GPSSPGGGGGPSSSSSBBSSSSSSSSSSPPSPPPPSSSPPSSSSSZSSPPSSPGGPSSPG",
                "GPSSPGGGGGGPPPSSSSSPPPPPPPPPPPSPPSSSSSSPPPPPPPSSPPSSPTTPSSPG",
                "GPSSPGGGGGGGGGPPSSPPSSSSSSSSGPSSSSPPSSSSPPGTGPSSSSSSPTGPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSSSSSSSSPPPPPPPPSSSSSPGPPSSSSSSSTTPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSPPPPSSSSSSSSSSPPSSSSSPSSSSPPPPPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSPPPSPGGPSSSSSSSSSSSPPSSSSPSSSSPBBBBTGPSSPG",
                "GPSSPGPPPPPPPPPPSSPGGGGGGGPPPPPPPPSSSSPPSSSSSSSSPBBBBBGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGGGGGGGGBBGPSSSSSPPSSSSSPPGGGGGGGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGBGGGGGGBBGGPSSSSSPPPPSSSPPPPPPGTPSSPG",
                "GPSSPGPSSPPPPPPPSSPGGGGGGGGGGGGGGGGPSSSSSSSPSSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGGPPPPGGGPPSSSSSPPSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGPSSSSPGGGPSPPPSPPSPPPPZZPPGPSSPG",
                "GPZZPPPZZPPPPPPPSSPPPPPPPPPPPSSSSPPPPPPPPPSPPSPPPSSSSSPPZZPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPZZPPPPPPPPPPPPPPPPSSPPPPPPPSSSSPPPPPPPSSPPPPPPPSSSSPPPZZPG",
                "GPSSPGPSSSSSPBBBBPSSSSPGGPSPPPSSPPPPPGGPSSSSPGBBPSSSSPGPSSPG",
                "GPSSPBSSSSSSPBBBBPSSSSPBBPSSSSSSSSSSSGGSSSSSPGBBGPSSPGBPSSPG",
                "GPSSPBPPSSSSPGGGGPSSSSPGGPSSSSSSSSSSPGGPSSSSPGGGGPSSPGBPSSPG",
                "GPSSPGGGPPSSPGGGGPSSPPGGGPSSPPPPPPSSPGGGPPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGGGBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGBBBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGPSPPSSPPPPPPZZPPPPPPZZPPPPPPSSPPPPPPZZPPPPPPZZSPGPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPGPSSPPPPPSSPPPPPPPPPPPPZZPPPPPZZPPPPPSSPPPPPSSPPPBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPGPSSPPPPPZZPPPPPPPPPPPPSSPPPPPSSPPPPPSSPPPPPSSPPGGPSSPG",
                "GPSSPGPSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSGBPSSPG",
                "GPSSPGSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGBPSSPG",
                "GPSSPGPPSSPPPPZZPPPPSSPPPPZZPPPPSSPPPPPPPPPPSSPPPPZZPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPGBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPBBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPPPPSSPPPPZZPPPPSSPPPPZZPPPPPPPPPPZZPPPPSSPGGPSSPG",
                "GPSSPGGPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGGPSSPG",
                "GPSSPGGSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGGGGPSSPG",
                "GPSSPGGPPPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPGGGGPSSPG",
                "GPSSPGGGGGGGGGGGGGBBBBGGBBBBPSSPBBBBGGBBBBGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSSS",
                "SSSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSSS",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG"
            };
        private static string[] map = defaultmap;
        private List<Location> route;


        public Routing FindRoute(int StartX, int StartY, int TargetX, int TargetY, Car car)
        {
            this.myCar = car;
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

                var adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, map);
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

        private List<Location> GetWalkableAdjacentSquares(int x, int y, string[] map)
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

            return proposedLocations.Where(l => map[l.Y][l.X] == 'S' || map[l.Y][l.X] == 'Z').ToList();
        }

        private Location CheckRoad(int x, int y, string[] map)
        {
            var proposedLocations = new List<Location>()
            {
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
                new Location { X = x, Y = y }
            };

            if (proposedLocations[1].Y == -1)
                proposedLocations[1] = new Location { X = x, Y = 59 };
            if (proposedLocations[2].Y == 60)
                proposedLocations[2] = new Location { X = x, Y = 0 };
            if (proposedLocations[3].X == -1)
                proposedLocations[3] = new Location { X = 59, Y = y };
            if (proposedLocations[4].X == 60)
                proposedLocations[4] = new Location { X = 0, Y = y };

            return proposedLocations.Where(l => map[l.Y][l.X] == 'S' || map[l.Y][l.X] == 'Z').ToList()[0];
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

        public string ToCommand()
        {
            List<string> directions = new List<string>();
            Direction direction = new Direction();

            if (route.Count == 1) { }
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
            return CreateCommand(directions);
        }

        private string CreateCommand(List<string> directions)
        {

            directions = CountForwards(directions);
            string actualDirection = GetCarDirection();
            string startDirection = directions[0];
            directions.RemoveAt(0);
            List<string> turnCommands = new List<string>();
            int speed = this.myCar.Speed;
            int hp = this.myCar.Life;
            string command = null;
            bool DidWeDoTheStartTurn = false;

            if (!DidWeDoTheStartTurn)
            {
                turnCommands = TurnToStartDirection(actualDirection, startDirection);
                DidWeDoTheStartTurn = true;
            }


            if (DoWeTurnAtStart(turnCommands))
            {
                command = TurnAtStart(ref turnCommands);
            }
            else if (DoWeAccelerate(directions[0], speed))
            {
                command = Accelerate();
            }
            else if (DoWeDecelerate())
            {
                command = Decelerate();
            }
            else if (DoWeTurn())
            {
                command = Turn("LEFT");
            }
            else if (DoWeGivePriority())
            {
                command = GivePriority();
            }
            else
            {
                command = DoNothing();
            }

            return command;

        }

        private bool DoWeTurnAtStart(List<string> turnCommands)
        {
            if (turnCommands.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string TurnAtStart(ref List<string> turnCommands)
        {
            string command = turnCommands[0];
            turnCommands.RemoveAt(0);

            return command;
        }

        private bool DoWeAccelerate(string forward, int speed)
        {
            int street;
            if (int.TryParse(forward, out street))
            {
                if (street >= 0 && speed == 0)
                    return true;
                else if (street >= 4 && speed == 1)
                    return true;
                else if (street >= 6 && speed == 2)
                    return true;
            }
            return false;
        }

        private string Accelerate()
        {
            return Command.ACCELERATION.ToString();
        }

        private bool DoWeDecelerate()
        {
            return false;
        }

        private string Decelerate()
        {
            return Command.DECELERATION.ToString();
        }

        private bool DoWeTurn()
        {
            return false;
        }

        private string Turn(string direction)
        {
            if (direction == "LEFT")
            {
                return Command.CAR_INDEX_LEFT.ToString();
            }
            else
            {
                return Command.CAR_INDEX_RIGHT.ToString();
            }
        }

        private bool DoWeGivePriority()
        {
            return false;
        }

        private string GivePriority()
        {
            return null;
        }

        private string DoNothing()
        {
            return Command.NO_OP.ToString();
        }

        private List<string> TurnToStartDirection(string actualDirecton, string startDirection)
        {
            List<string> commands = new List<string>();

            if (actualDirecton == "SOUTH" && startDirection == "NORTH" ||
                actualDirecton == "NORTH" && startDirection == "SOUTH" ||
                actualDirecton == "EAST" && startDirection == "WEST" ||
                actualDirecton == "WEST" && startDirection == "EAST")
            {
                commands.Add("CAR_INDEX_LEFT");
                commands.Add("CAR_INDEX_LEFT");
            }
            else if (actualDirecton == "SOUTH" && startDirection == "WEST" ||
                     actualDirecton == "WEST" && startDirection == "NORTH" ||
                     actualDirecton == "NORTH" && startDirection == "EAST" ||
                     actualDirecton == "EAST" && startDirection == "SOUTH")
            {
                commands.Add("CAR_INDEX_RIGHT");
            }
            else if (actualDirecton == "SOUTH" && startDirection == "EAST" ||
                     actualDirecton == "EAST" && startDirection == "NORTH" ||
                     actualDirecton == "NORTH" && startDirection == "WEST" ||
                     actualDirecton == "WEST" && startDirection == "SOUTH")
            {
                commands.Add("CAR_INDEX_LEFT");
            }

            return commands;
        }

        private string GetCarDirection()
        {
            string direction = "";

            switch (this.myCar.Direction)
            {
                case "UP": direction = global::Direction.NORTH.ToString(); break;
                case "DOWN": direction = global::Direction.SOUTH.ToString(); break;
                case "LEFT": direction = global::Direction.WEST.ToString(); break;
                case "RIGHT": direction = global::Direction.EAST.ToString(); break;
            }

            return direction;
        }

        public List<string> CountForwards(List<string> directions)
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
                "GPSSPGPSSSSPGBBPSSPGGGGGBBBBBGPPPPPPPPGGBBBBBBGBBPSSSPGPSSPG",
                "GPSSPBPSSSSSPGBPSSPGTGPSPPPPPPSSSSSSSSSPBBBBBBGBBPSGSPBPSSPG",
                "GPSSPBPSSSSSSPGPSSPGGGPSSSSSSSSSSSSSSSSPSPGGGPPPPPSGSPBPSSPG",
                "GPSSPGGPSSSSSPPPSSPPBBPSSSSSSSSSSPPSSSSSSPSPGPSSSSSGSPGPSSPG",
                "GPSSPGGGPSSSSSSSSSSSPPPSSPSSPPSSPPPPPSSSSSSPPPSSSSSSSSGPSSPG",
                "GPSSPGGGGPSSSSSSBBSSSSSSSSSSPPSSSSSSPPPSSSSSSZSSPPPPPPGPSSPG",
                "GPSSPGGGGGPSSSSSBBSSSSSSSSSSPPSPPPPSSSPPSSSSSZSSPPSSPGGPSSPG",
                "GPSSPGGGGGGPPPSSSSSPPPPPPPPPPPSPPSSSSSSPPPPPPPSSPPSSPTTPSSPG",
                "GPSSPGGGGGGGGGPPSSPPSSSSSSSSGPSSSSPPSSSSPPGTGPSSSSSSPTGPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSSSSSSSSPPPPPPPPSSSSSPGPPSSSSSSSTTPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSPPPPSSSSSSSSSSPPSSSSSPSSSSPPPPPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSPPPSPGGPSSSSSSSSSSSPPSSSSPSSSSPBBBBTGPSSPG",
                "GPSSPGPPPPPPPPPPSSPGGGGGGGPPPPPPPPSSSSPPSSSSSSSSPBBBBBGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGGGGGGGGBBGPSSSSSPPSSSSSPPGGGGGGGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGBGGGGGGBBGGPSSSSSPPPPSSSPPPPPPGTPSSPG",
                "GPSSPGPSSPPPPPPPSSPGGGGGGGGGGGGGGGGPSSSSSSSPSSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGGPPPPGGGPPSSSSSPPSSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGPSSSSPGGGPSPPPSPPSPPPPZZPPGPSSPG",
                "GPZZPPPZZPPPPPPPSSPPPPPPPPPPPSSSSPPPPPPPPPSPPSPPPSSSSSPPZZPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPZZPPPPPPPPPPPPPPPPSSPPPPPPPSSSSPPPPPPPSSPPPPPPPSSSSPPPZZPG",
                "GPSSPGPSSSSSPBBBBPSSSSPGGPSPPPSSPPPPPGGPSSSSPGBBPSSSSPGPSSPG",
                "GPSSPBSSSSSSPBBBBPSSSSPBBPSSSSSSSSSSSGGSSSSSPGBBGPSSPGBPSSPG",
                "GPSSPBPPSSSSPGGGGPSSSSPGGPSSSSSSSSSSPGGPSSSSPGGGGPSSPGBPSSPG",
                "GPSSPGGGPPSSPGGGGPSSPPGGGPSSPPPPPPSSPGGGPPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGGGBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPSSPGBBBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGPSPPSSPPPPPPZZPPPPPPZZPPPPPPSSPPPPPPZZPPPPPPZZSPGPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPBPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSPBPSSPG",
                "GPSSPGPSSPPPPPSSPPPPPPPPPPPPZZPPPPPZZPPPPPSSPPPPPSSPPPBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPBPSSPGGGPSSPGGGGGGGBBBPSSPGGGPSSPBBGPSSPGBBPSSPBGBPSSPG",
                "GPSSPGPSSPPPPPZZPPPPPPPPPPPPSSPPPPPSSPPPPPSSPPPPPSSPPGGPSSPG",
                "GPSSPGPSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSGBPSSPG",
                "GPSSPGSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGBPSSPG",
                "GPSSPGPPSSPPPPZZPPPPSSPPPPZZPPPPSSPPPPPPPPPPSSPPPPZZPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPGBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPBBPSSPBBPSSPBBPSSPBGPSSPGGGGGGGGPSSPGGPSSPGBPSSPG",
                "GPSSPGGPSSPPPPSSPPPPZZPPPPSSPPPPZZPPPPPPPPPPZZPPPPSSPGGPSSPG",
                "GPSSPGGPSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGGPSSPG",
                "GPSSPGGSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGGGGPSSPG",
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
                StringBuilder strB = new StringBuilder(map[Y]);
                strB[X] = 'C';
                map[Y] = strB.ToString();
            }
            foreach (var p in pedestrians)
            {
                int X = p.Position.PosX;
                int Y = p.Position.PosY;
                StringBuilder strB = new StringBuilder(map[Y]);
                strB[X] = 'H';
                map[Y] = strB.ToString();
            }
        }
    }
}

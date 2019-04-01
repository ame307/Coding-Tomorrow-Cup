using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarPathfinding
{
    class Location
    {
        public int X;
        public int Y;
        public int F;
        public int G;
        public int H;
        public Location Parent;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // draw map
            string[] map = new string[]
            {
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "GPSSPPPZZPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPZZPPPSSPP",
                "GPSSPGPSSPGBBGBBGGBBGGBBGBBGPSSPGBBGBBGGBBGGBBGBBGPSSPBPSSPG",
                "GPSSPBPSSPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPBPSSPG",
                "GPSSPBPSSPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPGPKKKPPGBBPSSPGGGGGBBBBBGPPPPPPPPGGBBBBBBGBBPSSSPGPSSPG",
                "GPSSPBPKKKKPPGBPSSPGTGPPPPPPPPPSSSSSSPPPBBBBBBGBBPSGSPBPSSPG",
                "GPSSPBPPKKKKPPGPSSPGGGPSSSSSSSSSSSSSSSSPPPGGGPPPPPSGSPBPSSPG",
                "GPSSPGGPPKKKKPPPSSPPBBPSSSSSSSSSSPPSSSSSSPPPGPSSSSSGSPGPSSPG",
                "GPSSPGGGPPKKKKPSSSSPPPPSSPSSPPSSPPPPPSSSSSSPPPSSSSSSSPGPSSPG",
                "GPSSPGGGGPPKKKSSBBSSSSSSSSSSPPSSSSSKPPPSSSSSSZSSPPPPPPGPSSPG",
                "GPSSPGGGGGPPKKSSBBSSSSSSSSSSPPSPPPPKKKPPPSSSSZSSPPSSPGGPSSPG",
                "GPSSPGGGGGGPPPPSSSSPPPPPPPPPPPSPPKKKKKKPPPPPPPSSPPSSPTTPSSPG",
                "GPSSPGGGGGGGGGPPSSPPSSSSSSSSGPSSSKPPKKKKPPGTGPSSSSSSPTGPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSSSSSSSSPPPPPPPPKKKKPPGPPSSSSSSPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSPPPPSSSSSSSSSKPPKKKKPPPKKSPPPPPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSPPPPPGGPPSSSSSSSSKKPPKKKKPKKKKPBBBBTGPSSPG",
                "GPSSPGPPPPPPPPPPSSPGGGGGGGPPPPPPPPKKKKPPKKKKKKKPPBBBBBGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGGGGGGGGBBGPPKKKKPPKKKKKPPGGGGGGGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGBGGGGGGBBGGPPKKKKPPPPKKKPPPPPPGTPSSPG",
                "GPSSPGPSSPPPPPPPSSPGGGGGGGGGGGGGGGGPPKKKSSSPKKSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGGPPPPGGGPPKSSSSPPKSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGPPSSPPGGGPPPPPPPPPPPPPZZPPGPSSPG",
                "GPZZPPPZZPPPPPPPSSPPPPPPPPPPPSSSSPPPPPPPPPPPPPPPPSSSSPPPZZPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPZZPPPPPPPPPPPPPPPPKKPPPPPPPSSSSPPPPPPPSSPPPPPPPSSSSPPPZZPG",
                "GPSSPGPSSKKPPBBBBPPKKKPGGPPPPPSSPPPPPGGPKKKPPGBBPPSSPPGPSSPG",
                "GPSSPBPSKKKKPBBBBPKKKKPBBPSSSSSSSSSSPGGPKKKSPGBBGPSSPGBPSSPG",
                "GPSSPBPPPKKSPGGGGPKKKPPGGPSSSSSSSSSSPGGPPKSSPGGGGPSSPGBPSSPG",
                "GPSSPGGGPPSSPGGGGPKKPPGGGPSSPPPPPPSSPGGGPPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPKKPGGGBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPKKPGBBBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
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

            foreach (var line in map)
                Console.WriteLine(line);

            // algorithm

            Location current = null;
            var start = new Location { X = 15, Y = 17 };
            var target = new Location { X = 53, Y = 38 };
            target = CheckRoad(target.X, target.Y, map, target);
            var openList = new List<Location>();
            var closedList = new List<Location>();
            var route = new List<Location>();
            int g = 0;

            // start by adding the original position to the open list
            openList.Add(start);

            while (openList.Count > 0)
            {
                // get the square with the lowest F score
                var lowest = openList.Min(l => l.F);
                current = openList.First(l => l.F == lowest);

                // add the current square to the closed list
                closedList.Add(current);

                // show current square on the map
                Console.SetCursorPosition(current.X, current.Y);
                Console.Write('.');
                Console.SetCursorPosition(current.X, current.Y);

                // remove it from the open list
                openList.Remove(current);

                // if we added the destination to the closed list, we've found a path
                if (closedList.FirstOrDefault(l => l.X == target.X && l.Y == target.Y) != null)
                    break;

                var adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, map, target);
                g++;

                foreach(var adjacentSquare in adjacentSquares)
                {
                    // if this adjacent square is already in the closed list, ignore it
                    if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X
                            && l.Y == adjacentSquare.Y) != null)
                        continue;

                    // if it's not in the open list...
                    if (openList.FirstOrDefault(l => l.X == adjacentSquare.X
                            && l.Y == adjacentSquare.Y) == null)
                    {
                        // compute its score, set the parent
                        adjacentSquare.G = g;
                        adjacentSquare.H = ComputeHScore(adjacentSquare.X, adjacentSquare.Y, target.X, target.Y);
                        adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                        adjacentSquare.Parent = current;

                        // and add it to the open list
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        // test if using the current G score makes the adjacent square's F score
                        // lower, if yes update the parent because it means it's a better path
                        if (g + adjacentSquare.H > adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                            adjacentSquare.Parent = current;
                        }
                    }
                }
            }

            // assume path was found; let's show it
            while (current != null)
            {
                Console.SetCursorPosition(current.X, current.Y);
                Console.Write('_');
                Console.SetCursorPosition(current.X, current.Y);
                route.Add(new Location { X = current.X, Y = current.Y });
                current = current.Parent;
            }

            // end

            Console.ReadLine();
        }

        static List<Location> GetWalkableAdjacentSquares(int x, int y, string[] map, Location target)
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
            if ((Math.Abs(target.X - x) + Math.Abs(target.Y - y)) < 3)
                return proposedLocations.ToList();
            else
                return proposedLocations.Where(l => map[l.Y][l.X] == 'S' || map[l.Y][l.X] == 'Z' || map[l.Y][l.X] == 'K').ToList();
        }

        static Location CheckRoad(int x, int y, string[] map, Location target)
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

            return proposedLocations.Where(l => map[l.Y][l.X] == 'S' || map[l.Y][l.X] == 'Z' || map[l.Y][l.X] == 'K' || map[l.Y][l.X] == 'P').ToList()[0];
        }

        static int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            string[] map = new string[]
            {
                "GPSSPGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGPSSPG",
                "PPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPP",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "SSSSSSSSSSSSSSSSSSSSSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                "GPSSPPPZZPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPZZPPPSSPP",
                "GPSSPGPSSPGBBGBBGGBBGGBBGBBGPSSPGBBGBBGGBBGGBBGBBGPSSPBPSSPG",
                "GPSSPBPSSPPPPPPPPPPPPPPPPPPPPSSPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPGPSSPG",
                "GPSSPBPSSSSSSSSZSSZSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPBPSSPG",
                "GPSSPBPSSPPPPPPPSSPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPSSPBPSSPG",
                "GPSSPGPKKKPPGBBPSSPGGGGGBBBBBGPPPPPPPPGGBBBBBBGBBPSSSPGPSSPG",
                "GPSSPBPKKKKPPGBPSSPGTGPPPPPPPPPSSSSSSPPPBBBBBBGBBPSGSPBPSSPG",
                "GPSSPBPPKKKKPPGPSSPGGGPSSSSSSSSSSSSSSSSPPPGGGPPPPPSGSPBPSSPG",
                "GPSSPGGPPKKKKPPPSSPPBBPSSSSSSSSSSPPSSSSSSPPPGPSSSSSGSPGPSSPG",
                "GPSSPGGGPPKKKKPSSSSPPPPSSPSSPPSSPPPPPSSSSSSPPPSSSSSSSPGPSSPG",
                "GPSSPGGGGPPKKKSSBBSSSSSSSSSSPPSSSSSKPPPSSSSSSZSSPPPPPPGPSSPG",
                "GPSSPGGGGGPPKKSSBBSSSSSSSSSSPPSPPPPKKKPPPSSSSZSSPPSSPGGPSSPG",
                "GPSSPGGGGGGPPPPSSSSPPPPPPPPPPPSPPKKKKKKPPPPPPPSSPPSSPTTPSSPG",
                "GPSSPGGGGGGGGGPPSSPPSSSSSSSSGPSSSKPPKKKKPPGTGPSSSSSSPTGPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSSSSSSSSPPPPPPPPKKKKPPGPPSSSSSSPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSSSSSPPPPSSSSSSSSSKPPKKKKPPPKKSPPPPPTTPSSPG",
                "GPSSPGGGGGGBBBGPSSPPPPPGGPPSSSSSSSSKKPPKKKKPKKKKPBBBBTGPSSPG",
                "GPSSPGPPPPPPPPPPSSPGGGGGGGPPPPPPPPKKKKPPKKKKKKKPPBBBBBGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGGGGGGGGBBGPPKKKKPPKKKKKPPGGGGGGGPSSPG",
                "GPSSPGPSSSSSSSSSSSPGGGGBGGGGGGBBGGPPKKKKPPPPKKKPPPPPPGTPSSPG",
                "GPSSPGPSSPPPPPPPSSPGGGGGGGGGGGGGGGGPPKKKSSSPKKSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGGPPPPGGGPPKSSSSPPKSSSSSSPGTPSSPG",
                "GPSSPGPSSPBGBBBPSSPGGGGGGGGGPPSSPPGGGPPPPPPPPPPPPPZZPPGPSSPG",
                "GPZZPPPZZPPPPPPPSSPPPPPPPPPPPSSSSPPPPPPPPPPPPPPPPSSSSPPPZZPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPSSSSSSSSSSSSSSSSSSSSSSSSSSSSBBSSSSSSSSSSSSSSSSSSBBSSSSSSPG",
                "GPZZPPPPPPPPPPPPPPPPKKPPPPPPPSSSSPPPPPPPSSPPPPPPPSSSSPPPZZPG",
                "GPSSPGPSSKKPPBBBBPPKKKPGGPPPPPSSPPPPPGGPKKKPPGBBPPSSPPGPSSPG",
                "GPSSPBPSKKKKPBBBBPKKKKPBBPSSSSSSSSSSPGGPKKKSPGBBGPSSPGBPSSPG",
                "GPSSPBPPPKKSPGGGGPKKKPPGGPSSSSSSSSSSPGGPPKSSPGGGGPSSPGBPSSPG",
                "GPSSPGGGPPSSPGGGGPKKPPGGGPSSPPPPPPSSPGGGPPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPKKPGGGBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
                "GPSSPGGBBPSSPGGGGPKKPGBBBPSSPGGGGPSSPGGGGPSSPGGGGPSSPGBPSSPG",
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
            if (map[y][x] == 'K')
                return Math.Abs(targetX - x) + Math.Abs(targetY - y)+50;
            else
                return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }
    }
}

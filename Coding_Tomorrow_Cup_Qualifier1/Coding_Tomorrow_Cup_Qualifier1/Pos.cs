using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Tomorrow_Cup_Qualifier1
{
    class Pos
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Pos()
        {

        }

        public Pos(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        public Pos FromString(string value)
        {
            string[] line = value.Split(',');
            PosX = int.Parse(line[0].Split(':')[1]);
            PosX = int.Parse(line[1].Split(':')[1]);
            return this;
        }
        
    }
}

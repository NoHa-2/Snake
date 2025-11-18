using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snek
    {
        public int x {  get; set; }
        public int y { get; set; }

        public Snek(int xCoord, int yCoord)
        {
            x = xCoord;
            y = yCoord;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iks_Oks.GameLogic
{
    public class Position
    { 
        public int positionX { get; set; }
        public int positionY { get; set; }

        public Position(int x, int y)
        {
            this.positionX = x;
            this.positionY = y;
        }
    }
}

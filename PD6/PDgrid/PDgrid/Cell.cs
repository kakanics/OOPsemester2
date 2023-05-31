using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PDgrid
{
    internal class Cell
    {
        public char value;
        public int x;
        public int y;

        public Cell(char value, int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
        }
        public char getValue()
        {
            return value;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public bool isPacmanPresent()
        {
            if (value == 'P') return true;
            return false;
        }
        public bool isGhostPresent()
        {
            if (value == 'G') return true;
            return false;
        }
    }
}

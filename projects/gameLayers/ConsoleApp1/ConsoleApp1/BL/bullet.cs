using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class bullet
    {
        public Vector2D coords;
        public bool isFacingRight;
        public bullet(Vector2D _coords, bool isFacingLeft)
        {
            this.coords = _coords;
            this.isFacingRight = isFacingLeft;
        }
        public bullet(bullet other)
        {
            this.coords = other.coords;
        }

        public void move()
        {
            if (isFacingRight)
            {
                    coords.x++;
            }
            else
            {
                    coords.x--;
            }
        }
    }
}

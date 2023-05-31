using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD4game
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
                if (coords.x + 1 < 20)
                {
                    coords.x++;
                }
            }
            else
            {
                if (coords.x - 1 > 0)
                {
                    coords.x--;
                }
            }
        }
    }
}
internal class Vector2D
{
    public int x;
    public int y;

    public Vector2D(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public Vector2D(Vector2D other)
    {
        this.x = other.x;
        this.y = other.y;
    }
    public void moveLeft()
    {
        x--;
    }
    public void moveRight()
    {
        x++;
    }
    public void moveUp()
    {
        y--;
    }
    public void MoveDown()
    {
        y++;
    }
}

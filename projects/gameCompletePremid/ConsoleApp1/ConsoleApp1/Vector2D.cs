using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
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
}
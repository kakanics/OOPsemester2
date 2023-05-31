using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDgrid
{
    internal class Ghost
    {
        int x;
        int y;
        string direction;
        float speed;
        char prevItem;
        char ghostChar = 'G';
        float deltaChange;
        Grid mazeGrid;

        public Ghost(int x, int y, string direction, float speed, char prevItem, char ghostChar, float deltaChange, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.speed = speed;
            this.ghostChar = ghostChar;
            this.prevItem = prevItem;
            this.deltaChange = deltaChange;
            this.mazeGrid = mazeGrid;
        }
        public void setDirection(string direction)
        {
            this.direction = direction;
        }
        public void remove()
        {
            mazeGrid.maze[y, x].value = ' ';
        }
        public void draw()
        {
            mazeGrid.maze[y, x].value = ghostChar;
        }
        public char getChar()
        {
            return mazeGrid.maze[y, x].value;
        }
        public void changeDelta()
        {
            deltaChange += speed;
        }
        public float getDelta()
        {
            return deltaChange;
        }
        public void setDeltaZero()
        {
            deltaChange = 0;
        }
        public void moveHorizontal()
        {
            if (direction == "right")
                x++;
            else if(direction == "left") x--;
            if (x == 8) setDirection("left");
            if (x == 1) setDirection("right");
        }
        public void moveVertical()
        {
            if (direction == "down")
                y++;
            else if (direction == "up") y--;

            if (y == 8) setDirection("up");
            if (y == 1) setDirection("down");
        }
        public int generateRandom()
        {
            Random random = new Random();
            return random.Next(0, 2);
        }
        public void MoveRandom()
        {
            if(generateRandom()==0)
            {
                moveHorizontal();
            }
            else
            {
                moveVertical();
            }
        }
        public void MoveSmart()
        {
            Cell pacman = mazeGrid.findPacman();
            if (pacman.x > x) x++;
            else x--;
            if (pacman.y > y) y++;
            else y--;
        }
        public double calculateDistance()
        {
            Cell pacman = mazeGrid.findPacman();
            return Math.Sqrt(Math.Pow(pacman.x - x, 2) + Math.Pow(pacman.y - y, 2));
        }
    }
}

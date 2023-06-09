using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        Random random = new Random();

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
            remove();
            if (direction == "right")
            {
                if (mazeGrid.maze[y + 1, x].value == ' ' || mazeGrid.maze[y + 1, x].value == 'P')
                    y++;
            }
            else if (direction == "left")
            {
                if (mazeGrid.maze[y - 1, x].value == ' ' || mazeGrid.maze[y - 1, x].value == 'P')
                    y--;
            }
            draw();
            if (y == 7) setDirection("left");
            if (y == 1) setDirection("right");
        }
        public void moveVertical()
        {
            remove();
            if (direction == "down")
            {
                if (mazeGrid.maze[y, x + 1].value == ' ' || mazeGrid.maze[y, x + 1].value == 'P')
                    x++;
            }
            else if (direction == "up")
            {
                if (mazeGrid.maze[y, x - 1].value == ' ' || mazeGrid.maze[y, x - 1].value == 'P')
                    x--;
            }
                draw();
            if (x == 7) setDirection("up");
            if (x == 1) setDirection("down");
        }
        public int generateRandom()
        {
            return random.Next(0, 2);
        }
        public void MoveRandom()
        {
            if(generateRandom()==0)
            {
                if(generateRandom()==0)
                    direction = "left";
                else
                    direction = "right";
                moveHorizontal();
            }
            else
            {
                if (generateRandom() == 0)
                    direction = "up";
                else
                    direction = "down";
                moveVertical();
            }
        }
        public void MoveSmart()
        {
            Cell pacman = mazeGrid.findPacman();
            if (pacman == null) return;
            remove();
            if (pacman.x > y)
            {
                if (mazeGrid.maze[y + 1, x].value == ' ' || mazeGrid.maze[y + 1, x].value == 'P')
                    y++;
            }
            else 
                if (mazeGrid.maze[y - 1, x].value == ' '|| mazeGrid.maze[y - 1, x].value == 'P')
                    y--;
            if (pacman.y > x)
            {
                if (mazeGrid.maze[y, x + 1].value == ' '|| mazeGrid.maze[y, x + 1].value == 'P')
                    x++;
            }else
                if (mazeGrid.maze[y, x - 1].value == ' ' || mazeGrid.maze[y, x - 1].value == 'P')
                    x--;
            draw();
        }
        public double calculateDistance()
        {
            Cell pacman = mazeGrid.findPacman();
            return Math.Sqrt(Math.Pow(pacman.x - x, 2) + Math.Pow(pacman.y - y, 2));
        }
    }
}

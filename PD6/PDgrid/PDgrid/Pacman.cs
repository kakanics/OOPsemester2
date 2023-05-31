using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDgrid
{
    internal class Pacman
    {
        int x;
        int y;
        int score;
        Grid mazeGrid;

        public Pacman(int x, int y, int score, Grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.score = score;
            this.mazeGrid = mazeGrid;
        }
        public void remove()
        {
            mazeGrid.maze[y, x].value = ' ';
        }
        public void draw()
        {
            mazeGrid.maze[y, x].value = 'P';
        }
        public void moveLeft()
        {
            if (mazeGrid.getLeftCell(mazeGrid.maze[y,x]).value==' ')
            x--;
        }
        public void moveRight()
        {
            if (mazeGrid.getRightCell(mazeGrid.maze[y, x]).value == ' ')
                x++;
        }
        public void moveDown()
        {
            if (mazeGrid.getBottomCell(mazeGrid.maze[y, x]).value == ' ')
                y++;
        }
        public void moveUp()
        {
            if (mazeGrid.getTopCell(mazeGrid.maze[y, x]).value == ' ')
                y--;
        }
        public void printScore()
        {
            Console.SetCursorPosition(2,20);
            Console.Write("Score: " + score);
        }
    }
}

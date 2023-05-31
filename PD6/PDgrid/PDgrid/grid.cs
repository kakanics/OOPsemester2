using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDgrid
{
    internal class Grid
    {
        public Cell[,] maze;
        public int rowSize;
        public int columnSize;

        public Grid(string path, int rowSize, int columnSize)
        {
            maze = new Cell[columnSize, rowSize];
            this.rowSize = rowSize;
            this.columnSize = columnSize;
            populateGrid(path);
        }
        public Cell getLeftCell(Cell c)
        {
            return maze[c.getX() - 1, c.getY() - 1];
        }
        public void populateGrid(string path)
        {
            StreamReader sr = new StreamReader(path);
            string line;
            int row;
            int height = 0;
            while ((line = sr.ReadLine()) != null)
            {
                {
                    row = 0;
                    while (row<rowSize)
                    {
                        maze[height, row] = new Cell(line[row],height, row) ;
                        row++;
                    }
                        height++;
                }
            }
        }
        public Cell getRightCell(Cell c)
        {
            return maze[c.getX() + 1, c.getY() - 1];
        }
        public Cell getTopCell(Cell c)
        {
            return maze[c.getX(), c.getY() - 1];
        }
        public Cell getBottomCell(Cell c)
        {
            return maze[c.getX(), c.getY() + 1];
        }
        public Cell findPacman()
        {
            foreach (Cell cell in maze)
            {
                if (cell.isPacmanPresent())
                {
                    return cell;
                }
            }
            return null;
        }
        public Cell findGhost()
        {
            foreach (Cell cell in maze)
            {
                if (cell.isGhostPresent())
                {
                    return cell;
                }
            }
            return null;
        }
        public void draw()
        {
            foreach (var i in maze)
            {
                if (i == null) continue;
                Console.SetCursorPosition(i.getX(), i.getY());
                    {
                    Console.Write(i.getValue());
                    }
            }
        }
    }
}

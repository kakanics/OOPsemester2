﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Cell
    {
        private int x;
        private int y;
        private Grid grid;
        private GameObject currentGameObject;

        public GameObject GetGameObject() => currentGameObject;
        public void setObject(GameObject gameObject) => currentGameObject = gameObject;
        public int getX() => x;
        public int getY() => y;
        public Cell(int x, int y, Grid grid)
        {
            this.x = x;
            this.y = y;
            this.grid = grid;
        }
        public Cell getNextCell(directions direction)
        {
            if (direction == directions.UP)
            {
                return grid.getCell(y - 1, x);
            }
            if (direction == directions.DOWN)
            {
                return grid.getCell(y+1, x);
            }
            if (direction == directions.LEFT)
            {
                return grid.getCell(y, x-1);
            }
            if (direction == directions.RIGHT)
            {
                return grid.getCell(y, x+1);
            }
            return null;
        }
    }
}

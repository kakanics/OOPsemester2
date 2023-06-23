using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Grid
    {
        private Cell[,] completeGrid;
        private int rows;
        private int columns;

        public int getRows() => rows;
        public int getColumns() => columns;
        public Grid(string path)
        {
            loadGrid(path);
        }
        private void loadGrid(string path)
        {
            countRowsAndColumns(path);
            completeGrid = new Cell[this.rows, this.columns];
            StreamReader sr = new StreamReader(path);
            string record = "";
            int rows = 0;
            int columns = 0;
            while ((record = sr.ReadLine()) != null)
            {
                columns = 0;
                while (columns<this.columns)
                {
                    GameObject gameObject = new GameObject(record[columns], GameObject.getGameObjectType(record[columns]));
                    Cell cell = new Cell(columns, rows, this);
                    cell.setObject(gameObject);
                    gameObject.setCurrentCell(cell);
                    completeGrid[rows, columns] = cell;
                    columns++;
                }
                rows++;
            }
            sr.Close();
        }
        private void countRowsAndColumns(string path)
        {
            StreamReader sr = new StreamReader(path);
            string record = "";
            int rows = 0;
            int columns = 0;
            while ((record = sr.ReadLine()) != null)
            {
                columns = record.Length;
                rows++;
            }
            this.columns = columns;
            this.rows = rows;
            sr.Close();
        }
        public Cell getCell(int row, int column)
        {
            return completeGrid[row, column];
        }
    }
}

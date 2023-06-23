using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ghost_Smart : Ghost
    {
        PacmanPlayer player;
        public Ghost_Smart(char displayChar, PacmanPlayer player) : base(displayChar) 
        {
            this.player = player;
        }
        public Ghost_Smart(char displayChar, int x, int y, Grid grid, PacmanPlayer player) : base(displayChar)
        {
            this.player = player;
            setCurrentCell(grid.getCell(x, y));
        }
        public Ghost_Smart(int x, int y, Grid grid, PacmanPlayer player)
        {
            this.player = player;
            setCurrentCell(grid.getCell(x, y));
        }

        public override Cell Move()
        {
            Directions direction = minDistance();
            //Console.SetCursorPosition(0, 0);
            //Console.Write(direction);
            setCurrentCell(currentCell.getNextCell(direction));
            return currentCell;
        }
        private Directions minDistance()
        {
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };
            Directions direction = Directions.UP;
            gameObjectType nextObjectType = currentCell.getNextCell(direction).GetGameObject().getType();
            if (nextObjectType == gameObjectType.NONE || nextObjectType == gameObjectType.REWARD)
            {
                distance[0] = (calculateDistance(currentCell.getX(), currentCell.getY() - 1, player.getCurrentCell().getX(), player.getCurrentCell().getY()));
            }
            direction = Directions.DOWN;
            nextObjectType = currentCell.getNextCell(direction).GetGameObject().getType();
            if (nextObjectType == gameObjectType.NONE || nextObjectType == gameObjectType.REWARD)
            {
                distance[1] = (calculateDistance(currentCell.getX(), currentCell.getY() + 1, player.getCurrentCell().getX(), player.getCurrentCell().getY()));
            }
            direction = Directions.RIGHT;
            nextObjectType = currentCell.getNextCell(direction).GetGameObject().getType();
            if (nextObjectType == gameObjectType.NONE || nextObjectType == gameObjectType.REWARD)
            {
                distance[2] = (calculateDistance(currentCell.getX() + 1, currentCell.getY(), player.getCurrentCell().getX(), player.getCurrentCell().getY()));
            }
            direction = Directions.LEFT;
            nextObjectType = currentCell.getNextCell(direction).GetGameObject().getType();
            if (nextObjectType == gameObjectType.NONE || nextObjectType == gameObjectType.REWARD)
            {
                distance[3] = (calculateDistance(currentCell.getX() - 1, currentCell.getY(), player.getCurrentCell().getX(), player.getCurrentCell().getY()));
            }
            //Console.SetCursorPosition(0, 1);
            //Console.Write(distance[0]);
            //Console.SetCursorPosition(0, 2);
            //Console.Write(distance[1]);
            //Console.SetCursorPosition(0, 3);
            //Console.Write(distance[2]);
            //Console.SetCursorPosition(0, 4);
            //Console.Write(distance[3]);
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                return Directions.UP;
            }
            if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                return Directions.DOWN;
            }
            if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                return Directions.RIGHT;
            }
            else
            {
                return Directions.LEFT;
            }
        }

        static double calculateDistance(int X, int Y, int pX, int pY)
        {
            return Math.Sqrt(Math.Pow((pX - X), 2) + Math.Pow((pY - Y), 2));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PacmanPlayer:GameObject
    {
        private int score = 0;
        public PacmanPlayer(int x, int y, Grid grid) : base('P', gameObjectType.PLAYER)
        {
            setCurrentCell(grid.getCell(x, y));
        }
        public int getScore() => score;
        public Cell move(Directions direction)
        {
            if (currentCell.getNextCell(direction).GetGameObject().getType() == gameObjectType.NONE)
            {
                setCurrentCell(currentCell.getNextCell(direction));
            }
            if (currentCell.getNextCell(direction).GetGameObject().getType() == gameObjectType.REWARD)
            {
                setCurrentCell(currentCell.getNextCell(direction));
                score++;
            }
            return currentCell;
        }
    }
    
}

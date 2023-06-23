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
        public PacmanPlayer(int x, int y, Grid grid) : base('P', gameObjectType.PLAYER)
        {
            setCurrentCell(grid.getCell(x, y));
        }
        public void move(directions direction)
        {
            if (currentCell.getNextCell(direction).GetGameObject().getType() == gameObjectType.NONE)
            {
                Console.SetCursorPosition(currentCell.getX(), currentCell.getY());
                Console.Write(' ');
                setCurrentCell(currentCell.getNextCell(direction));
            }
        }
    }
    enum directions
    {
        UP,DOWN, LEFT, RIGHT
    }
}

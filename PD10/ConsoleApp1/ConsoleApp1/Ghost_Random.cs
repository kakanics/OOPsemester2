using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ghost_Random : Ghost
    {
        Random RNG = new Random();
        public Ghost_Random(char displayChar) : base(displayChar){}
        public Ghost_Random(char displayChar, int x, int y, Grid grid) : base(displayChar)
        {
            setCurrentCell(grid.getCell(x, y));
        }
        public Ghost_Random(int x, int y, Grid grid)
        {
            setCurrentCell(grid.getCell(x, y));
        }

        public override Cell Move()
        {
            Directions direction = (Directions)(RNG.Next(0,4));
            gameObjectType nextObjectType = currentCell.getNextCell((Directions)direction).GetGameObject().getType();
            if (nextObjectType == gameObjectType.NONE)
            {
                setCurrentCell(currentCell.getNextCell(direction));
            }
            return currentCell;
        }
    }
}

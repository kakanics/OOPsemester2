using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Ghost_Vertical : Ghost
    {
        private VerticalDirections direction;
        public Ghost_Vertical(VerticalDirections direction)
        {
            this.direction = direction;
        }
        public Ghost_Vertical(VerticalDirections direction, char displayChar) : base(displayChar)
        {
            this.direction = direction;
        }
        public Ghost_Vertical(VerticalDirections direction, char displayChar, int x, int y, Grid grid) : base(displayChar)
        {
            setCurrentCell(grid.getCell(x, y));
            this.direction = direction;
        }
        public Ghost_Vertical(VerticalDirections direction, int x, int y, Grid grid)
        {
            setCurrentCell(grid.getCell(x, y));
            this.direction = direction;
        }

        public override Cell Move()
        {
            gameObjectType nextObjectType = currentCell.getNextCell((Directions)direction).GetGameObject().getType();
            if (nextObjectType == gameObjectType.NONE)
            {
                setCurrentCell(currentCell.getNextCell((Directions)direction));
            }
            if (nextObjectType == gameObjectType.WALL || nextObjectType == gameObjectType.REWARD)
            {
                direction = ((Directions)direction == Directions.UP) ? VerticalDirections.DOWN : VerticalDirections.UP;
            }
            return currentCell;
        }
    }
}

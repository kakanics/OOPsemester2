using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Ghost : GameObject
    {
        public Ghost(char displayChar):base(displayChar, gameObjectType.ENEMY)
        {

        }
        public Ghost() : base('G', gameObjectType.ENEMY)
        {

        }
        public char getCharAtCurrentPlace(Grid grid)
        {
            return grid.getCell(currentCell.getY(), currentCell.getX()).GetGameObject().getDisplayChar();
        }
        public abstract Cell Move();
    }
}

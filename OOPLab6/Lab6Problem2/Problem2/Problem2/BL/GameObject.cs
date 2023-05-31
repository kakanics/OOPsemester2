using Problem2.UL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.BL
{
    internal class GameObject
    {
        public char[,] shape;
        public Point startingPosition;
        public Boundary premises;
        public string direction;

        public GameObject(char[,] shape, Point startingPosition)
        {
            this.shape = shape;
            this.startingPosition = startingPosition;
            premises = new Boundary();
            direction="LeftToRight";
        }
        public GameObject(char[,] shape, Point startingPosition, Boundary premises, string direction) : this(shape, startingPosition)
        {
            this.shape = shape;
            this.startingPosition = startingPosition;
            this.premises = premises;
            this.direction = direction;
        }
        public void Move()
        {
            if(direction=="LeftToRight")
            {
                if(startingPosition.getX()<premises.topRight.getX())
                {
                    startingPosition.setX(startingPosition.getX() + 1);
                }
            }
            else if (direction == "RightToLeft")
            {
                if (startingPosition.getX() > premises.topLeft.getX())
                {
                    startingPosition.setX(startingPosition.getX() -1);
                }
            }
            else if (direction == "PatrolR")
            {
                if (startingPosition.getX() > premises.topRight.getX())
                {
                    startingPosition.setX(startingPosition.getX() - 1);
                }
                else
                {
                    direction = "PatrolL";
                }
            }
            else if (direction == "PatrolL")
            {
                if (startingPosition.getX() < premises.topLeft.getX())
                {
                    startingPosition.setX(startingPosition.getX() + 1);
                }
                else
                {
                    direction = "PatrolR";
                }
            }
            else if (direction == "Projectile")
            {
                startingPosition.setX(startingPosition.getX()+2);
                startingPosition.setY(startingPosition.getY()+1);
            }
            else if (direction == "Diagnol")
            {
                if (startingPosition.getX() < premises.bottomRight.getX())
                {
                    startingPosition.setX(startingPosition.getX() + 1);
                }
                if (startingPosition.getY() < premises.bottomRight.getY())
                {
                    startingPosition.setY(startingPosition.getY() + 1);
                }
            }
        }
        public void erase()
        {
            UILayer.erase(shape, startingPosition.getX(), startingPosition.getY());
        }
        public void draw()
        {
            UILayer.draw(shape, startingPosition.getX(), startingPosition.getY());
        }
    }
}

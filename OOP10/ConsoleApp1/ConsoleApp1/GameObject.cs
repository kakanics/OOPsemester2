using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GameObject
    {
        private char displayCharacter;
        protected Cell currentCell;
        private gameObjectType Type;
        public char getDisplayChar()=>displayCharacter; 
        public Cell getCurrentCell()=>currentCell;
        public void setCurrentCell(Cell cell)=>currentCell=cell;
        public gameObjectType getType() => Type;
        public GameObject(char displayCharacter, gameObjectType type)
        {
            this.displayCharacter = displayCharacter;
            Type = type;
        }
        public static gameObjectType getGameObjectType(char displayChar)
        {
            if(displayChar == ' ')
            {
                return gameObjectType.NONE;
            }
            else if (displayChar == '|' || displayChar == '%')
            {
                return gameObjectType.WALL;
            }
            else if (displayChar == 'P')
            {
                return gameObjectType.PLAYER;
            }
            else if (displayChar == 'G')
            {
                return gameObjectType.ENEMY;
            }
            else
            {
                return gameObjectType.REWARD;
            }
        }
    }
    enum gameObjectType{
        WALL, PLAYER, ENEMY, REWARD, NONE
    }
}

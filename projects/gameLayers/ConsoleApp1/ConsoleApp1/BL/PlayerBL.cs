using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BL
{
    internal class PlayerBL:Vector2D
    {
        char[,] player = { { 'O' }, { '|' } };
        int playerTimer = 3;
        int health = 3;
        int score = 0;

        public PlayerBL(int x, int y) : base(x,y)
        {

        }
        public char[,] getPlayer()
        { 
            return player; 
        }
        public int getHealth()
        {
            return health;
        }
        public int getScore()
        {
            return score;
        }
        public void setScore(int score)
        {
            this.score = score;
        }
        public void setHealth(int health)
        {
            this.health = health;
        }
        public int getPlayerTimer()
        {
            return playerTimer;
        }
        public void setPlayerTimer(int timer)
        {
            this.playerTimer = timer;
        }
        public void right(char[,] maze)
        {
            if (maze[y, x + 1] == ' ' && maze[y + 1, x + 1] == ' ')
            {
                moveRight();
            }
        }
        public void left(char[,] maze)
        {
            if (maze[y, x - 1] == ' ' && maze[y + 1, x - 1] == ' ')
            {
                moveLeft();
            }
        }
        public void up(char[,] maze)
        {
            if (maze[y - 1, x] == ' ')
            {
                moveUp();
            }
        }
        public void down(char[,] maze)
        {
            if (maze[y + 2, x] == ' ')
            {
                MoveDown();
            }
        }
    }
}
 
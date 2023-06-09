using ConsoleApp1.BL;
using ConsoleApp1.UL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DL
{
    internal class BulletDL
    {
        public static List<bullet> bullets = new List<bullet> ();
        public static void move()
        {
            foreach (bullet b in bullets)
            {
                GenericUL.eraseXY(b.coords.x, b.coords.y);
                b.move();
                GenericUL.printThing('.',b.coords.x, b.coords.y);
            }
        }
        public static void generateBullet(Vector2D playerPos, bool dirRight)
        {
            Vector2D tempVar = new Vector2D(playerPos);
            if (dirRight)
            {
                if (playerPos.x + 1 < 73)
                {
                    bullet _bullet = new bullet(tempVar, dirRight);
                    _bullet.coords.moveRight();
                    bullets.Add(_bullet);
                }
            }
            else
            {
                if (playerPos.x - 1 > 1)
                {
                    bullet _bullet = new bullet(tempVar, dirRight);
                    _bullet.coords.moveLeft();
                    bullets.Add(_bullet);
                }
            }
        }
        public static void DestroyBullet(Vector2D EnemyPos, char[,] maze, ref bool gameRunning, PlayerBL player)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if ((bullets[i].coords.x == EnemyPos.x && bullets[i].coords.y == EnemyPos.y) ||
                    bullets[i].coords.x == EnemyPos.x && bullets[i].coords.y == EnemyPos.y + 1)
                {
                    player.setScore(player.getScore()+1);
                    GenericUL.eraseXY(bullets[i].coords.x, bullets[i].coords.y);
                    bullets.RemoveAt(i);
                    if (player.getScore() >= 20)
                    {
                        gameRunning = false;
                        Console.Clear();
                        Console.Write("you win");
                        Console.ReadLine();
                    }
                }
                else if ((bullets[i].coords.x == player.x && bullets[i].coords.y == player.y) ||
                    bullets[i].coords.x == player.x && bullets[i].coords.y == player.y + 1)
                {
                    player.setHealth(player.getHealth()-1);
                    GenericUL.eraseXY(bullets[i].coords.x, bullets[i].coords.y);
                    bullets.RemoveAt(i);
                    if (player.getHealth() <= 0)
                    {
                        gameRunning = false;
                        Console.Clear();
                        Console.Write("you lose");
                        Console.ReadLine();
                    }
                }
                else if (bullets[i].isFacingRight)
                {
                    if (maze[bullets[i].coords.y, bullets[i].coords.x + 1] == '#')
                    {
                        GenericUL.eraseXY(bullets[i].coords.x, bullets[i].coords.y);
                        bullets.RemoveAt(i);
                    }
                }
                else if (bullets[i].coords.x == 0)
                {
                    bullets.RemoveAt(i);
                }
                else
                {
                    if (maze[bullets[i].coords.y, bullets[i].coords.x - 1] == '#')
                    {
                        GenericUL.eraseXY(bullets[i].coords.x, bullets[i].coords.y);
                        bullets.RemoveAt(i);
                    }
                }
            }
        }
    }
}

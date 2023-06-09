using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp1.DL;
using ConsoleApp1.UL;
using ConsoleApp1.BL;
using EZInput;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] maze = new char[17, 75];
            
            char[,] enemy = { { 'X' }, { '|' } };

            string pathMaze = "G:\\files\\maze.txt";
            int timer = 5;
            int enemyMoveTimer = 5;
            Vector2D EnemyPos = new Vector2D(15, 5);
            bool enemyDirRIght = false;
            PlayerBL player = new PlayerBL(5,5);
            
            mazeLoader(pathMaze, maze);
            GenericUL.printMaze(maze);
            bool gameRunning = true;
            while (gameRunning)
            {
                GenericUL.eraser(player.getPlayer(), player.x, player.y);
                GenericUL.eraser(enemy, EnemyPos.x, EnemyPos.y);
                if (timer % 2 == 0)
                {
                    if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow))
                    {
                        player.right(maze);
                    }
                    if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow))
                    {
                        player.left(maze);

                    }
                    if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow))
                    {
                        player.up(maze);
                    }
                    if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow))
                    {
                        player.down(maze);
                    }
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.Space) && player.getPlayerTimer()<= 0)
                {
                    player.setPlayerTimer(8);
                    BulletDL.generateBullet(new Vector2D(player.x, player.y), true);
                }
                player.setPlayerTimer(player.getPlayerTimer() - 1);
                if (timer <= 0)
                {
                    timer = 20;
                    BulletDL.generateBullet(EnemyPos, !enemyDirRIght);
                }
                else
                {
                    timer--;
                }
                if (enemyMoveTimer <= 0)
                {
                    enemyMoveTimer = 10;
                    if (enemyDirRIght)
                    {
                        if (maze[EnemyPos.y, EnemyPos.x + 1] == ' ')
                            EnemyPos.moveRight();
                        if (maze[EnemyPos.y, EnemyPos.x + 1] == '#')
                            enemyDirRIght = false;
                    }

                    if (!enemyDirRIght)
                    {
                        if (maze[EnemyPos.y, EnemyPos.x - 1] == ' ')
                            EnemyPos.moveLeft();
                        if (maze[EnemyPos.y, EnemyPos.x - 1] == '#')
                            enemyDirRIght = true;
                    }
                }
                else
                {
                    enemyMoveTimer--;
                }

                if ((EnemyPos.x == player.x && EnemyPos.y == player.y) ||
                    (EnemyPos.x == player.x && EnemyPos.y + 1 == player.y) ||
                    (EnemyPos.x == player.x && EnemyPos.y == player.y + 1))
                {
                    gameRunning = false;
                    Console.Clear();
                    Console.Write("YOU LOSE");
                    Console.ReadLine();
                }
                GenericUL.printHealth(player.getHealth(), player.getScore());
                BulletDL.DestroyBullet(EnemyPos, maze, ref gameRunning, player);
                BulletDL.move();
                GenericUL.printer(player.getPlayer(), player.x, player.y);
                GenericUL.printer(enemy, EnemyPos.x, EnemyPos.y);
                Thread.Sleep(20);
            }
        }
        
        
        static void mazeLoader(string path, char[,] maze)
        {
            StreamReader streamReader = new StreamReader(path);
            string line;
            int y = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                int x = 0;
                foreach (char i in line)
                {
                    maze[y, x] = i;
                    x++;
                }
                y++;
            }
        }
    }
}

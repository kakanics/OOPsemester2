using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;

namespace ConsoleApp1
{
    internal class Program
    {
        const int TotalBulletCount = 30;
        static void Main(string[] args)
        {
            char[,] maze =
        {
            {'#' ,'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            {'#' ,' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#' ,' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#' ,' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#' ,' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#' ,' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#' ,' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#' ,' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#' ,' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#' ,' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
            {'#' ,'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
        };
            int[] bulletX = new int[TotalBulletCount];
            int[] bulletY = new int[TotalBulletCount];
            bool[] activeBullet = new bool[TotalBulletCount];
            bool[] bulletDirRight = new bool[TotalBulletCount];
            for (int i = 0; i < TotalBulletCount; i++)
                activeBullet[i] = false;
            int timer = 5;
            int enemyMoveTimer = 5;
            int bulletCount = 0;
            int playerX = 5, playerY = 6;
            int enemyX = 10, enemyY = 5;
            bool enemyDirRIght = false;
            int playerTimer = 3;
            int health = 3;
            int score = 0;

            printMaze(maze);
            bool gameRunning = true;
            while (gameRunning)
            {
                eraseXY(enemyX, enemyY);
                eraseXY(playerX, playerY);
                if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    if (maze[playerY, playerX + 1] == ' ')
                    {
                        playerX++;
                    }
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    if (maze[playerY, playerX - 1] == ' ')
                    {
                        playerX--;
                    }

                }
                if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    if (maze[playerY - 1, playerX] == ' ')
                    {
                        playerY--;
                    }
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    if (maze[playerY + 1, playerX] == ' ')
                    {
                        playerY++;
                    }
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.Space)&&playerTimer<=0)
                {
                    playerTimer = 8;
                    generateBullet(bulletX, bulletY, activeBullet, ref bulletCount, playerX, playerY, bulletDirRight, true);
                }
                playerTimer--;
                if (bulletCount < 0)
                {
                    bulletCount = 0;
                }
                if (timer <= 0)
                {
                    timer = 20;
                    generateBullet(bulletX, bulletY, activeBullet, ref bulletCount, enemyX, enemyY, bulletDirRight, !enemyDirRIght);
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
                        if (maze[enemyY, enemyX + 1] == ' ')
                            enemyX++;
                        if (maze[enemyY, enemyX + 1] == '#')
                            enemyDirRIght = false;
                    }

                    if (!enemyDirRIght)
                    {
                        if (maze[enemyY, enemyX - 1] == ' ')
                            enemyX--;
                        if (maze[enemyY, enemyX - 1] == '#')
                            enemyDirRIght = true;
                    }
                }
                else
                {
                    enemyMoveTimer--;
                }

                if (enemyX == playerX && enemyY == playerY)
                {
                    gameRunning = false;
                    Console.Clear();
                    Console.Write("YOU LOSE");
                    Console.ReadLine();
                }
                printHealth(health, score);
                move(bulletX, bulletY, activeBullet, bulletCount, bulletDirRight);
                DestroyBullet(bulletX, bulletY, activeBullet, ref bulletCount, enemyX, enemyY, maze, playerX, playerY, bulletDirRight, ref gameRunning, ref health, ref score);
                printThing('P', playerX, playerY);
                printThing('G', enemyX, enemyY);
                Thread.Sleep(20);
            }
        }
        static void printMaze(char[,] maze)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void printThing(char thing, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(thing);
        }
        static void eraseXY(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }
        static void generateBullet(int[] bulletX, int[] bulletY, bool[] activeBullets, ref int count, int playerX, int playerY, bool[] enemyDir, bool dirRight)
        {
            if (count < TotalBulletCount)
            {
                if (dirRight)
                {
                    if (!(playerX + 1 > 20))
                    {
                        bulletX[count] = playerX + 1;
                        bulletY[count] = playerY;
                        activeBullets[count] = true;
                        enemyDir[count] = dirRight;
                        count++;
                    }
                }
                else
                {
                    if (!(playerX - 1 < 0))
                    {
                        bulletX[count] = playerX - 1;
                        bulletY[count] = playerY;
                        activeBullets[count] = true;
                        enemyDir[count] = dirRight;
                        count++;
                    }
                }
            }
        }
        static void move(int[] bulletX, int[] bulletY, bool[] activeBullets, int count, bool[] bulletDirRight)
        {
            for (int i = 0; i < TotalBulletCount; i++)
            {
                if (activeBullets[i])
                {
                    if (bulletDirRight[i])
                    {
                        if (bulletX[i] + 1 < 20)
                        {
                            eraseXY(bulletX[i], bulletY[i]);
                            bulletX[i]++;
                            printThing('.', bulletX[i], bulletY[i]);
                        }
                    }
                    else
                    {
                        if (bulletX[i] - 1 > 0)
                        {
                            eraseXY(bulletX[i], bulletY[i]);
                            bulletX[i]--;
                            printThing('.', bulletX[i], bulletY[i]);
                        }
                    }
                }
            }
        }
        static void printHealth(int health, int score)
        {
            Console.SetCursorPosition(30, 2);
            Console.Write("Health: {0}  ", health);
            Console.SetCursorPosition(30, 3);
            Console.Write("Score: {0}  ", score);
        }
        static void DestroyBullet(int[] bulletX, int[] bulletY, bool[] activeBullets, ref int count, int enemyX, int enemyY, char[,] maze, int playerX, int playerY, bool[] bulletDir, ref bool gameRunning, ref int health, ref int score)
        {
            for (int i = 0; i < TotalBulletCount; i++)
            {
                if (activeBullets[i])
                {
                    if (bulletX[i] == enemyX && bulletY[i] == enemyY)
                    {
                        score++;
                        activeBullets[i] = false;
                        eraseXY(bulletX[i], bulletY[i]);
                        for (int j = i; j < count - 1; j++)
                        {
                            bulletX[j] = bulletX[j + 1];
                            bulletY[j] = bulletY[j + 1];
                            activeBullets[j] = activeBullets[j + 1];
                            bulletDir[j] = bulletDir[j + 1];
                        }
                        count--;
                        if (score >= 20)
                        {
                            gameRunning = false;
                            Console.Clear();
                            Console.Write("you win");
                            Console.ReadLine();
                        }
                    }
                    if (bulletX[i] == playerX && bulletY[i] == playerY)
                    {
                        health--;
                        activeBullets[i] = false;
                        eraseXY(bulletX[i], bulletY[i]);
                        for (int j = i; j < count - 1; j++)
                        {
                            bulletX[j] = bulletX[j + 1];
                            bulletY[j] = bulletY[j + 1];
                            activeBullets[j] = activeBullets[j + 1];
                            bulletDir[j] = bulletDir[j + 1];
                        }
                        count--;
                        if (health <= 0)
                        {
                            gameRunning = false;
                            Console.Clear();
                            Console.Write("you lose");
                            Console.ReadLine();
                        }
                    }
                    if (activeBullets[i])
                    {
                        if (bulletDir[i])
                        {
                            if (maze[bulletY[i], bulletX[i] + 1] == '#')
                            {
                                activeBullets[i] = false;
                                eraseXY(bulletX[i], bulletY[i]);
                                for (int j = i; j < count - 1; j++)
                                {
                                    bulletX[j] = bulletX[j + 1];
                                    bulletY[j] = bulletY[j + 1];
                                    activeBullets[j] = activeBullets[j + 1];
                                    bulletDir[j] = bulletDir[j + 1];
                                }
                                count--;
                            }
                        }
                        else
                        {
                            if (maze[bulletY[i], bulletX[i] - 1] == '#')
                            {
                                activeBullets[i] = false;
                                eraseXY(bulletX[i], bulletY[i]);
                                for (int j = i; j < count - 1; j++)
                                {
                                    bulletX[j] = bulletX[j + 1];
                                    bulletY[j] = bulletY[j + 1];
                                    activeBullets[j] = activeBullets[j + 1];
                                    bulletDir[j] = bulletDir[j + 1];
                                }
                                count--;
                            }
                        }
                    }
                }
            }
        }
    }
}
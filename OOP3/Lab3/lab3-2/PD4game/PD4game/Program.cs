﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;

namespace PD4game
{
    internal class Program
    {
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
            List<bullet> bullets = new List<bullet>();
            int timer = 5;
            int enemyMoveTimer = 5;
            Vector2D playerPos = new Vector2D(5,5);
            Vector2D EnemyPos = new Vector2D(15,5);
            bool enemyDirRIght = false;
            int playerTimer = 3;
            int health = 3;
            int score = 0;

            printMaze(maze);
            bool gameRunning = true;
            while (gameRunning)
            {
                eraseXY(EnemyPos.x, EnemyPos.y);
                eraseXY(playerPos.x, playerPos.y);
                if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    if (maze[playerPos.y, playerPos.x + 1] == ' ')
                    {
                        playerPos.moveRight();
                    }
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    if (maze[playerPos.y, playerPos.x - 1] == ' ')
                    {
                        playerPos.moveLeft();
                    }

                }
                if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    if (maze[playerPos.y - 1, playerPos.x] == ' ')
                    {
                        playerPos.moveUp();
                    }
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    if (maze[playerPos.y + 1, playerPos.x] == ' ')
                    {
                        playerPos.MoveDown();
                    }
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.Space) && playerTimer <= 0)
                {
                    playerTimer = 8;
                    generateBullet(bullets, playerPos, true);
                }
                playerTimer--;
                if (timer <= 0)
                {
                    timer = 20;
                    generateBullet(bullets, EnemyPos, !enemyDirRIght);
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

                if (EnemyPos.x == playerPos.x && EnemyPos.y == playerPos.y)
                {
                    gameRunning = false;
                    Console.Clear();
                    Console.Write("YOU LOSE");
                    Console.ReadLine();
                }
                printHealth(health, score);
                move(bullets);
                DestroyBullet(bullets, EnemyPos, maze, playerPos, ref gameRunning, ref health, ref score);
                printThing('P', playerPos.x, playerPos.y);
                printThing('G', EnemyPos.x, EnemyPos.y);
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
        static void generateBullet(List<bullet> bullets, Vector2D playerPos, bool dirRight)
        {
            Vector2D tempVar = new Vector2D(playerPos);
            if (dirRight)
            {
                if (playerPos.x + 1 < 18)
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
        static void move(List<bullet> bullets)
        {

            foreach (bullet _bullet in bullets)
            {
                eraseXY(_bullet.coords.x, _bullet.coords.y);
                _bullet.move();
                printThing('.', _bullet.coords.x, _bullet.coords.y);
            }
        }
        static void printHealth(int health, int score)
        {
            Console.SetCursorPosition(30, 2);
            Console.Write("Health: {0}  ", health);
            Console.SetCursorPosition(30, 3);
            Console.Write("Score: {0}  ", score);
        }
        static void DestroyBullet(List<bullet> bullets, Vector2D EnemyPos, char[,] maze, Vector2D playerPos, ref bool gameRunning, ref int health, ref int score)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].coords == EnemyPos)
                {
                    score++;
                    eraseXY(bullets[i].coords.x, bullets[i].coords.y);
                    bullets.RemoveAt(i);
                    if (score >= 20)
                    {
                        gameRunning = false;
                        Console.Clear();
                        Console.Write("you win");
                        Console.ReadLine();
                    }
                }
                else if (bullets[i].coords == playerPos)
                {
                    health--;
                    eraseXY(bullets[i].coords.x, bullets[i].coords.y);
                    bullets.RemoveAt(i);
                    if (health <= 0)
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
                        eraseXY(bullets[i].coords.x, bullets[i].coords.y);
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
                        eraseXY(bullets[i].coords.x, bullets[i].coords.y);
                        bullets.RemoveAt(i);
                    }
                }
            }
        }
    }
}
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Snake
{
    class Program
    {
        static Random rand = new Random();

        static int screenWidth = 120;
        static int screenHeight = 30;

        static ConsoleKey KeyPress;

        static LinkedList<Snek> sneke = new();
        static Snek[] tailTemp = new Snek[1];
        static int Direction;
        static int x;
        static int y; // coords for the snake
        static int horizontalSnakeSpeed;
        static int verticalSnakeSpeed;

        static int foodY;
        static int foodX;
        static int score;

        static bool isDead;
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.CursorVisible = false;
                Console.Clear();

                Direction = 3;
                isDead = false;
                x = 60;
                y = 15;
                horizontalSnakeSpeed = 100;
                verticalSnakeSpeed = 140;
                score = 0;

                Console.BufferHeight = screenHeight;

                // prints out the border and creates the snake
                for (int i = 0; i < screenWidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("=");
                    Console.SetCursorPosition(40, 2);
                    Console.Write("SNAKE GAME");
                    Console.SetCursorPosition(60, 2);
                    Console.Write($"Score: {score}");
                    Console.SetCursorPosition(i, 4);
                    Console.Write("=");
                    Console.SetCursorPosition(i, 29);
                    Console.Write("=");
                }
                for (int i = 5; i < screenHeight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("#");
                    Console.SetCursorPosition(119, i);
                    Console.Write("#");
                }
                MakeSnek();

                // game loop

                food();

                while (!isDead)
                {
                    // input
                    if (Console.KeyAvailable)
                    {
                        KeyPress = Console.ReadKey(true).Key;
                        InputHandler();
                    }
                    Movement();

                    // game logic such as collision
                    if (sneke.First.Value.x >= screenWidth - 1 || sneke.First.Value.y >= screenHeight - 1 || sneke.First.Value.y <= 4 || sneke.First.Value.x <= 1)
                    {
                        isDead = true;
                    }
                    foreach (Snek segment in sneke.Skip(1))
                    {
                        if (sneke.First.Value.x == segment.x && sneke.First.Value.y == segment.y)
                        {
                            isDead = true;
                        }
                    }
                    if (sneke.First.Value.x == foodX && sneke.First.Value.y == foodY)
                    {
                        score += 1;
                        sneke.AddLast(new Snek(sneke.Last.Value.x, sneke.Last.Value.y));
                        food();
                    }

                    // display stuff
                    if (Direction == 0 || Direction == 1)
                    {
                        Thread.Sleep(verticalSnakeSpeed);
                    }
                    else
                    {
                        Thread.Sleep(horizontalSnakeSpeed);
                    }
                    Update();
                }

                Death();
                // waits for the user to press space or esc
                while (true)
                {
                    KeyPress = Console.ReadKey(true).Key;
                    if (KeyPress == ConsoleKey.Spacebar || KeyPress == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
                if (KeyPress == ConsoleKey.Spacebar)
                {
                    continue;
                }
                else if (KeyPress == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
        // updates the screen or rather the parts that need to be updated
        static void Update()
        {
            Console.SetCursorPosition(foodX, foodY);
            Console.Write("%");
  
            Console.SetCursorPosition(sneke.First.Value.x, sneke.First.Value.y);
            Console.Write("■");
            
            Console.SetCursorPosition(tailTemp[0].x, tailTemp[0].y);
            Console.Write(' ');
        }

        // checks for user input and makes sure the snake cant double back into itself
        static void InputHandler()
        {
            switch (KeyPress)
            {
                case ConsoleKey.W:
                    if (Direction != 1)
                    {
                        Direction = 0;
                    }
                    break;
                case ConsoleKey.S:
                    if (Direction != 0)
                    {
                        Direction = 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (Direction != 3)
                    {
                        Direction = 2;
                    }
                    break;
                case ConsoleKey.A:
                    if (Direction != 2)
                    { 
                        Direction = 3;
                    } break;
            }
        }
        static void Movement()
        {
            switch (Direction)
            {
                case 0: // UP
                    sneke.AddFirst(new Snek(sneke.First.Value.x, sneke.First.Value.y - 1)); break;
                case 1: // DOWN
                    sneke.AddFirst(new Snek(sneke.First.Value.x, sneke.First.Value.y + 1)); break;
                case 2: // RIGHT
                    sneke.AddFirst(new Snek(sneke.First.Value.x + 1, sneke.First.Value.y)); break;
                case 3: // LEFT
                    sneke.AddFirst(new Snek(sneke.First.Value.x - 1, sneke.First.Value.y)); break;
            }

            tailTemp[0] = new Snek(sneke.Last.Value.x, sneke.Last.Value.y);
            sneke.RemoveLast();
        }
        static void food()
        {
            foodX = rand.Next(2, 118);
            foodY = rand.Next(6, 28);

            foreach (Snek segment in sneke)
            {
                if (foodX == segment.x  && foodY == segment.y)
                {
                    food();
                }
            }
            Console.SetCursorPosition(60, 2);
            Console.Write($"Score: {score}");

            horizontalSnakeSpeed = (int)((double)horizontalSnakeSpeed - horizontalSnakeSpeed * 0.05);
            verticalSnakeSpeed = (int)((double)verticalSnakeSpeed - verticalSnakeSpeed * 0.05);
        }
        static void Death()
        {
            foreach (Snek segment in sneke)
            {
                Console.SetCursorPosition(segment.x, segment.y);
                Console.Write("X");
            }
            Console.SetCursorPosition(35, 16);
            Console.Write("GAME OVER PRESS SPACE TO RESTART OR ESC TO EXIT");
        }
        static void MakeSnek()
        {
            sneke.Clear();
            for (int i = 0; i <= 10; i++)
            {
                sneke.AddLast(new Snek(x + i, y));
            }
        }
    }
}
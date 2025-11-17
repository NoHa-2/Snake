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
        static int x = 60;
        static int y = 15;

        static int foodY;
        static int foodX;
        static int score;

        static bool isDead = false;
        
        static void Main(string[] args)
        {
            Console.BufferHeight = screenHeight;
            
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

            Console.CursorVisible = false;
            MakeSnek();

            // game loop

            food();

            while (!isDead)
            {
                // timing and input
                if (Console.KeyAvailable)
                {
                    KeyPress = Console.ReadKey(true).Key;
                    InputHandler();
                }
                Movement();

                // game logic
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
                    Thread.Sleep(140);
                }
                else
                {
                    Thread.Sleep(100);
                }
                Update();
            }
        }
        static void Update()
        {
            Console.SetCursorPosition(foodX, foodY);
            Console.Write("%");
            foreach (Snek segment in sneke)
            {
                Console.SetCursorPosition(segment.x, segment.y);
                Console.Write("■");
            }

            Console.SetCursorPosition(tailTemp[0].x, tailTemp[0].y);
            Console.Write(' ');
        }
        static void InputHandler()
        {
            switch (KeyPress)
            {
                case ConsoleKey.W:
                    Direction = 0; break;
                case ConsoleKey.S:
                    Direction = 1; break;
                case ConsoleKey.D:
                    Direction = 2; break;
                case ConsoleKey.A:
                    Direction = 3; break;
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
            foodX = rand.Next(2, 28);
            foodY = rand.Next(6, 25);

            Console.SetCursorPosition(60, 2);
            Console.Write($"Score: {score}");
        }
        static void MakeSnek()
        {
            for (int i = 0; i <= 10; i++)
            {
                sneke.AddLast(new Snek(x + i, y));
            }
        }
    }
}
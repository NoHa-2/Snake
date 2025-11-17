using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Snake
{
    class Program
    {
        static int screenWidth = 120;
        static int screenHeight = 30;

        static ConsoleKey KeyPress;

        static LinkedList<Snek> sneke = new();
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
                if (sneke.First.Value.x >= screenWidth - 2 || sneke.First.Value.y >= screenHeight - 2 || sneke.First.Value.y <= 5 || sneke.First.Value.x <= 2)
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

                // display stuff
                Update();
            }
            
        }
        static void Update()
        {
            for (int i = 1; i < screenWidth - 1; i++)
            {
                for (int j = 6; j < screenHeight - 1; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
            foreach (Snek segment in sneke)
            {
                Console.SetCursorPosition(segment.x, segment.y);
                Console.Write("■");
            }
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

            sneke.RemoveLast();
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
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

        static Stack<Snek> sneke = new();
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
            }



            Console.CursorVisible = false;
            MakeSnek();
      

            // game loop
            while (true)
            {
                // timing and input
                /*
                KeyPress = Console.ReadKey().Key;
                InputHandler();
                */

                // game logic

                // display stuff
                Movement();
                Update();
            }
            
        }

        static void Update()
        {
            for (int i = 0; i < screenWidth; i++)
            {
                for (int j = 6; j < screenHeight; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
                foreach (Snek segment in sneke)
                {
                    Console.SetCursorPosition(segment.x, segment.y);
                    Console.Write("o");
                }
            }
        }
        static void MakeSnek()
        {
            for (int i = 0; i <= 10; i++)
            {
                sneke.Push(new Snek(x + i, y));
            }
        }
        static void Movement()
        {
            
        }
        static void InputHandler()
        {
            switch (KeyPress)
            {
                case ConsoleKey.UpArrow:
                    Direction = -1;
                    break;
                case ConsoleKey.DownArrow:
                    Direction = 1;
                    break;
                case ConsoleKey.RightArrow:
                    Direction = -1;
                    break;
                case ConsoleKey.LeftArrow:
                    Direction = 1;
                    break;
                default:
                    break;
            }
        }
    }
}
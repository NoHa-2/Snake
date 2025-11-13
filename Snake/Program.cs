



namespace Snake
{
    class Program
    {
        static int screenWidth = 120;
        static int screenHeight = 80;
        static List<Snek> sneke = new();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            MakeSnek();

            for (int i = 0; i < sneke.Count; i++)
            {
                Console.SetCursorPosition(sneke[i].x, sneke[i].y);
                Console.Write("x");
            }

            // game loop
            while (true)
            {
                // timing and input

                // game logic

                // display stuff
                Update();
            }
        }

        static void Update()
        {
            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
                Console.SetCursorPosition(i, 5);
                Console.Write("=");
            }
        }
        public static void MakeSnek()
        {
            int x = 60;
            int y = 15;
            for (int i = 0; i <= 10; i++)
            {
                sneke.Add(new Snek(x + i, y));
            }
        }
    }
}
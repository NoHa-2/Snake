



namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BufferWidth = 120;
            Console.BufferHeight = 80;

            while (true)
            {
                Update();
            }
        }

        static void Update()
        {
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
                Console.SetCursorPosition(i, 5);
                Console.Write("=");
            }
        }
    }
}
namespace Banco.Presentation
{
    public static class Viewer
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            DrawScreen();
        }

        public static void DrawScreen()
        {
            Console.Write("+");
            for (int i = 0; i <= 70; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");
            for (int lines = 0; lines <= 13; lines++)
            {
                Console.Write("|");
                for (int i = 0; i <= 70; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.Write("\n");
            }
            Console.Write("+");
            for (int i = 0; i <= 70; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
        }

        public static void Mensagem(string message)
        {
            for (int lines = 2; lines < 12; lines++)
            {
                Console.SetCursorPosition(3, lines);
                Console.Write("");
            }
            Console.SetCursorPosition(3, 2);
            Console.WriteLine(message);
        }
    }
}
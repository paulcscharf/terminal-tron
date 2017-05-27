
using System;

namespace TerminalTron
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            try
            {
                new Game().Run();
            }
            catch (Exception e)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.WriteLine(e);
            }
            Console.CursorVisible = true;
        }
    }
}

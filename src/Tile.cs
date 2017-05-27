using System;

namespace TerminalTron
{
    internal struct Tile
    {
        public bool IsBlocked { get; }
        public char Character { get; }
        public ConsoleColor Color { get; }

        public Tile(bool isBlocked, char character, ConsoleColor color)
        {
            IsBlocked = isBlocked;
            Character = character;
            Color = color;
        }

        public void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Draw();
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.Write(Character);
        }
    }
}

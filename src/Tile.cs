using System;

namespace TerminalTron
{
    internal struct Tile
    {
        private readonly bool isBlocked;
        private readonly char character;
        private readonly ConsoleColor color;

        public Tile(bool isBlocked, char character, ConsoleColor color)
        {
            this.isBlocked = isBlocked;
            this.character = character;
            this.color = color;
        }

        public bool IsBlocked { get { return this.isBlocked; } }
        public char Character { get { return this.character; } }
        public ConsoleColor Color { get { return this.color; } }

        public void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            this.Draw();
        }

        public void Draw()
        {
            Console.ForegroundColor = this.color;
            Console.Write(this.character);
        }
    }
}
using System;
using static System.ConsoleColor;

namespace TerminalTron
{
    internal class TileMap
    {
        private readonly Tile[,] tiles;

        public int Width { get; }
        public int Height { get; }

        public TileMap(int width, int height)
        {
            Width = width;
            Height = height;
            tiles = new Tile[width, height];

            for (var x = 0; x < width; x++)
            {
                tiles[x, 0] = new Tile(true, '═', White);
                tiles[x, height - 1] = new Tile(true, '═', White);
            }
            for (var y = 0; y < height; y++)
            {
                tiles[0, y] = new Tile(true, '║', White);
                tiles[width - 1, y] = new Tile(true, '║', White);
            }

            tiles[0, 0] = new Tile(true, '╔', White);
            tiles[width - 1, 0] = new Tile(true, '╗', White);
            tiles[0, height - 1] = new Tile(true, '╚', White);
            tiles[width - 1, height - 1] = new Tile(true, '╝', White);

            DrawAll();
        }

        private void DrawAll()
        {
            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    Console.SetCursorPosition(x, y);
                    tiles[x, y].Draw();
                }
            }
        }

        public Tile this[int x, int y]
        {
            get => tiles[x, y];
            set
            {
                tiles[x, y] = value;
                value.Draw(x, y);
            }
        }
    }
}

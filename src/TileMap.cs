using System;

namespace TerminalTron
{
    internal class TileMap
    {
        private readonly int width;
        private readonly int height;

        private readonly Tile[,] tiles;

        public TileMap(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.tiles = new Tile[width, height];

            for (int x = 0; x < width; x++)
            {
                this.tiles[x, 0] = new Tile(true, '#', ConsoleColor.White);
                this.tiles[x, height - 1] = new Tile(true, '#', ConsoleColor.White);
            }
            for (int y = 0; y < height; y++)
            {
                this.tiles[0, y] = new Tile(true, '#', ConsoleColor.White);
                this.tiles[width - 1, y] = new Tile(true, '#', ConsoleColor.White);
            }

            this.DrawAll();
        }

        private void DrawAll()
        {
            for (int y = 0; y < this.height; y++)
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < this.width; x++)
                {
                    this.tiles[x, y].Draw();
                }
            }
        }

        public int Width { get { return this.width; } }
        public int Height { get { return this.height; } }

        public Tile this[int x, int y]
        {
            get { return this.tiles[x, y]; }
            set
            {
                this.tiles[x, y] = value;
                value.Draw(x, y);
            }
        }
    }
}
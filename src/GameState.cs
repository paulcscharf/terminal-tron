using System;
using System.Collections.Generic;

namespace TerminalTron
{
    internal class GameState
    {
        private readonly List<Bike> bikes = new List<Bike>();

        public double Time { get; private set; }

        public TileMap Tilemap { get; }

        public GameState(int width, int height)
        {
            Tilemap = new TileMap(width, height);

            bikes.Add(new Bike(this, 5, height / 2, Direction.Right, ConsoleColor.Yellow, new KeyboardBikeController()));
        }

        public void Update(double elapsedTime)
        {
            Time += elapsedTime;

            foreach (var bike in bikes)
            {
                bike.Update(elapsedTime);
            }
            
            Console.SetCursorPosition(Tilemap.Width, Tilemap.Height - 1);
        }
    }
}

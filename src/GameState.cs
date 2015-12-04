using System;
using System.Collections.Generic;

namespace TerminalTron
{
    internal class GameState
    {
        private readonly TileMap tilemap;
        private readonly List<Bike> bikes = new List<Bike>();

        private double time;

        public GameState(int width, int height)
        {
            this.tilemap = new TileMap(width, height);

            this.bikes.Add(new Bike(this, 5, height / 2, Direction.Right, ConsoleColor.Yellow, new KeyboardBikeController()));
        }

        public double Time { get { return this.time; } }
        public TileMap Tilemap { get { return this.tilemap; } }

        public void Update(double elapsedTime)
        {
            this.time += elapsedTime;

            foreach (var bike in this.bikes)
            {
                bike.Update(elapsedTime);
            }
        }
    }
}
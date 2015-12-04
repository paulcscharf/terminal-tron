using System;

namespace TerminalTron
{
    internal interface IBikeController
    {
        Direction Control(double elapsedTime);
    }

    internal class KeyboardBikeController : IBikeController
    {
        public Direction Control(double elapsedTime)
        {
            if (InputManager.WasHit(ConsoleKey.UpArrow))
                return Direction.Up;
            if (InputManager.WasHit(ConsoleKey.DownArrow))
                return Direction.Down;
            if (InputManager.WasHit(ConsoleKey.LeftArrow))
                return Direction.Left;
            if (InputManager.WasHit(ConsoleKey.RightArrow))
                return Direction.Right;
            return null;
        }
    }

    internal class Bike
    {
        private const double stepTime = 0.2;

        private readonly GameState game;
        private readonly ConsoleColor color;
        private readonly IBikeController controller;

        private int x;
        private int y;
        private Direction direction;
        private double nextStep;

        public Bike(GameState game, int x, int y, Direction direction, ConsoleColor color, IBikeController controller)
        {
            this.game = game;
            this.x = x;
            this.y = y;
            this.direction = null;//direction;
            this.color = color;
            this.controller = controller;
            this.nextStep = game.Time + stepTime;
            this.Draw();
        }

        public void Update(double elapsedTime)
        {
            var newDirection = this.controller.Control(elapsedTime);
            if (newDirection != null && !newDirection.IsOppositeOf(this.direction))
            {
                this.direction = newDirection;
            }


            if (this.nextStep < this.game.Time)
            {
                this.nextStep += stepTime;


                if (this.direction == null)
                {
                    return;
                }


                this.doStep();
            }
        }

        private void doStep()
        {
            this.game.Tilemap[this.x, this.y] = new Tile(true, '+', this.color);
            this.x += this.direction.StepX;
            this.y += this.direction.StepY;
            this.Draw();
        }

        private void Draw()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.ForegroundColor = this.color;
            Console.Write("@");
        }
    }
}
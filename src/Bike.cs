using System;
using System.Collections.Generic;
using static System.ConsoleKey;
using static TerminalTron.Direction;

namespace TerminalTron
{
    internal interface IBikeController
    {
        Direction Control(double elapsedTime);
    }

    internal class KeyboardBikeController : IBikeController
    {
        private static bool hit(ConsoleKey key) => InputManager.WasHit(key);

        public Direction Control(double elapsedTime)
        {
            if (hit(UpArrow) || hit(W)) return Up;
            if (hit(DownArrow) || hit(S)) return Down;
            if (hit(LeftArrow) || hit(A)) return Left;
            if (hit(RightArrow) || hit(D)) return Right;
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
        private Direction nextDirection;
        private double nextStep;

        public bool dead;

        public Bike(GameState game, int x, int y, Direction direction, ConsoleColor color, IBikeController controller)
        {
            this.game = game;
            this.x = x;
            this.y = y;
            this.direction = null;
            this.color = color;
            this.controller = controller;

            nextDirection = this.direction;
            nextStep = game.Time + stepTime;
            Draw();
        }

        public void Update(double elapsedTime)
        {
            if (dead)
                return;

            updateMovement(elapsedTime);
        }

        private void updateMovement(double elapsedTime)
        {
            var newDirection = controller.Control(elapsedTime);
            if (newDirection != null && (direction == null || newDirection != direction.Opposite))
            {
                nextDirection = newDirection;
            }

            if (nextStep < game.Time)
            {
                nextStep += stepTime;

                if (nextDirection == null)
                    return;

                doStep();
            }
        }

        private void doStep()
        {
            var trailTileIndex = trailTiles[direction ?? nextDirection][nextDirection];
            var trailTile = trailThinCurved[trailTileIndex];
            direction = nextDirection;
            game.Tilemap[x, y] = new Tile(true, trailTile, color);
            x += direction.StepX;
            y += direction.StepY;

            if (game.Tilemap[x, y].IsBlocked)
                die();

            Draw();
        }

        private void die()
        {
            dead = true;
        }

        private void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(dead ? "X" : "@");
        }

        private static readonly string trailThin = "━┃┏┓┗┛";
        private static readonly string trailThick = "─│┌┐└┘";
        private static readonly string trailThinCurved = "─│╭╮╰╯";

        private static readonly Dictionary<Direction, Dictionary<Direction, int>>
            trailTiles = new Dictionary<Direction, Dictionary<Direction, int>>
            {
                { Up, new Dictionary<Direction, int> {
                    { Up, 1 }, { Left, 3 }, { Right, 2 }
                } },
                { Down, new Dictionary<Direction, int> {
                    { Down, 1 }, { Left, 5 }, { Right, 4 }
                } },
                { Left, new Dictionary<Direction, int> {
                    { Up, 4 }, { Down, 2 }, { Left, 0 }
                } },
                { Right, new Dictionary<Direction, int> {
                    { Up, 5 }, { Down, 3 }, { Right, 0 }
                } },
            };
    }
}

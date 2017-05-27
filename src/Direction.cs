namespace TerminalTron
{
    internal class Direction
    {
        public static readonly Direction Up = new Direction(0, -1);
        public static readonly Direction Down = new Direction(0, 1);
        public static readonly Direction Left = new Direction(-1, 0);
        public static readonly Direction Right = new Direction(1, 0);

        static Direction()
        {
            Up.Opposite = Down;
            Down.Opposite = Up;
            Left.Opposite = Right;
            Right.Opposite = Left;
        }

        public int StepX { get; }
        public int StepY { get; }
        public Direction Opposite { get; private set; }

        private Direction(int stepX, int stepY)
        {
            StepX = stepX;
            StepY = stepY;
        }

        public bool IsOppositeOf(Direction other)
            => other != null && StepX == -other.StepX && StepY == -other.StepY;
    }
}

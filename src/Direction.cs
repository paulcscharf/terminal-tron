namespace TerminalTron
{
    internal class Direction
    {
        public static readonly Direction Up = new Direction(0, -1);
        public static readonly Direction Down = new Direction(0, 1);
        public static readonly Direction Left = new Direction(-1, 0);
        public static readonly Direction Right = new Direction(1, 0);

        private readonly int stepX;
        private readonly int stepY;

        private Direction(int stepX, int stepY)
        {
            this.stepX = stepX;
            this.stepY = stepY;
        }

        public int StepX { get { return this.stepX; } }
        public int StepY { get { return this.stepY; } }

        public bool IsOppositeOf(Direction other)
        {
            return other != null && this.stepX == -other.stepX && this.stepY == -other.stepY;
        }
    }
}
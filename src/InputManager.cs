using System;
using System.Collections.Generic;

namespace TerminalTron
{
    internal static class InputManager
    {
        private static readonly HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>();

        public static void Update()
        {
            pressedKeys.Clear();
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true);
                pressedKeys.Add(key.Key);
            }
        }

        public static bool WasHit(ConsoleKey key)
        {
            return pressedKeys.Contains(key);
        }
    }
}
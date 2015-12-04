﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TerminalTron
{
    internal class Game
    {
        private GameState gameState;

        public Game()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(60, 20);
            Console.SetBufferSize(60, 20);
            this.gameState = new GameState(Console.WindowWidth, Console.WindowHeight - 1);
            Console.CursorVisible = true;
        }

        public void Run()
        {
            var delayTimer = new Stopwatch();

            const int fps = 100;
            var timePerFrame = TimeSpan.FromSeconds(1.0 / fps);

            var globalTimer = Stopwatch.StartNew();
            var lastFrame = globalTimer.Elapsed;

            while (true)
            {
                delayTimer.Start();

                var timeStep = globalTimer.Elapsed - lastFrame;
                lastFrame += timeStep;

                InputManager.Update();

                if (InputManager.WasHit(ConsoleKey.Escape))
                    break;

                this.gameState.Update(timeStep.TotalSeconds);

                var elapsed = delayTimer.Elapsed;
                var wait = timePerFrame - elapsed;
                if (wait > TimeSpan.Zero)
                {
                    Task.Delay(wait);
                }

                delayTimer.Reset();

            }
        }
    }
}
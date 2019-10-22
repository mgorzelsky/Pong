using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;

namespace Pong
{
    public delegate void ThreadStart();
    public enum ThingsToHit { Nothing, Wall, Paddle, Ball, Goal }
    class Game
    {
        Ball ball = new Ball();
        Paddle leftPaddle = new Paddle();
        Paddle rightPaddle = new Paddle();

        public static int Width { get; set; }
        public static int Height { get; set; }

        //Main gameplay loop. Updates every 1/60th of a second for a 60 hz refresh rate.
        public void Start()
        {
            Thread inputThread = new Thread(WaitForInput);
            inputThread.Start();

            ThingsToHit[,] internalState = new ThingsToHit[Game.Width, Game.Height];
            Renderer screenRenderer = new Renderer();

            while (true)
            {
                internalState = new ThingsToHit[Game.Width, Game.Height];
                for (int x = 0; x < Game.Width; x++)
                    internalState[x, 0] = ThingsToHit.Wall;
                for (int x = 0; x < Game.Width; x++)
                    internalState[x, Game.Height - 1] = ThingsToHit.Wall;

                internalState[ball.BallPosition.X, ball.BallPosition.Y] = ThingsToHit.Ball;

                screenRenderer.DrawScreen(internalState);

                //Console.Clear();
                //Console.SetCursorPosition(ball.BallPosition.X, ball.BallPosition.Y);
                //Console.Write("o");
                Thread.Sleep(1000/60000);
            }
        }

        private void WaitForInput()
        {
            while (true)
            {
                Console.WriteLine(Console.ReadKey());
            }
        }
    }
}

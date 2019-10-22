using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;

namespace Pong
{
    public delegate void ThreadStart();
    public enum ThingsToHit { Nothing, Wall, Paddle, Ball }
    class Game
    {
        Ball ball = new Ball();
        Paddle leftPaddle = new Paddle();
        Paddle rightPaddle = new Paddle();
        Renderer render = new Renderer();

        ThingsToHit[,] internalState;
        private int width;
        private int height;
        public Game(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        //Main gameplay loop. Updates every 1/60th of a second for a 60 hz refresh rate.
        public void Start()
        {
            Thread inputThread = new Thread(WaitForInput);
            inputThread.Start();

            while (true)
            {
                internalState = new ThingsToHit[width, height];
                SetBoundaries(ref internalState);
                CollisionCheck();
                internalState[ball.BallPosition.X, ball.BallPosition.Y] = ThingsToHit.Ball;
                render.DrawScreen(internalState, width, height);
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

        private void CollisionCheck()
        {
            if (ball.BallPosition.X >= 80 || ball.BallPosition.X <= 0)
                ball.Bounce(ThingsToHit.Paddle);
            if (ball.BallPosition.Y >= 30 || ball.BallPosition.Y <= 0)
                ball.Bounce(ThingsToHit.Wall);
        }

        private void SetBoundaries(ref ThingsToHit[,] internalState)
        {
            for (int x = 0; x < width; x++)
            {
                internalState[x, 0] = ThingsToHit.Wall;
                internalState[x, height - 1] = ThingsToHit.Wall;
            }
            for (int y = 0; y < height; y++)
            {
                internalState[0, y] = ThingsToHit.Paddle;
                internalState[height - 1, y] = ThingsToHit.Paddle;
            }
        }
    }
}

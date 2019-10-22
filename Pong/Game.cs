using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;

namespace Pong
{
    public delegate void ThreadStart();
    public enum ThingsToHit { Nothing, Wall, Paddle }
    class Game
    {
        Ball ball = new Ball();
        Paddle leftPaddle = new Paddle();
        Paddle rightPaddle = new Paddle();
        //Main gameplay loop. Updates every 1/60th of a second for a 60 hz refresh rate.
        public void Start()
        {
            Thread inputThread = new Thread(WaitForInput);
            inputThread.Start();

            while (true)
            {
                CollisionCheck();
                Console.Clear();
                Console.SetCursorPosition(ball.BallPosition.X, ball.BallPosition.Y);
                Console.Write("o");
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
    }
}

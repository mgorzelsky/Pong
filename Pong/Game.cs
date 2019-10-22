using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;

namespace Pong
{
    //All the possible states of any poisition within the internalState[,]
    public enum ThingsToHit { Nothing, Wall, Paddle, Ball, Goal }
    
    class Game
    {
        public static int Width { get; set; }
        public static int Height { get; set; }

        Ball ball = new Ball();
        Paddle leftPaddle;
        Paddle rightPaddle;

        public Game(int width, int height)
        {
            Width = width;
            Height = height;
            this.leftPaddle = new Paddle("left");
            this.rightPaddle = new Paddle("right");
        }

        public void Start()
        {
            Thread inputThread = new Thread(WaitForInput);
            inputThread.Start();

            ThingsToHit[,] internalState = new ThingsToHit[Game.Width, Game.Height];
            Renderer screenRenderer = new Renderer();

            //Main gameplay loop. Updates every 1/60th of a second for a 60 hz refresh rate.
            while (true)
            {
                internalState = new ThingsToHit[Game.Width, Game.Height];
                for (int x = 0; x < Game.Width; x++)
                    internalState[x, 0] = ThingsToHit.Wall;
                for (int x = 0; x < Game.Width; x++)
                    internalState[x, Game.Height - 1] = ThingsToHit.Wall;

                foreach (Point paddlePosition in leftPaddle.PaddlePosition)
                {
                    internalState[paddlePosition.X, paddlePosition.Y] = ThingsToHit.Paddle;
                }

                internalState[ball.BallPosition.X, ball.BallPosition.Y] = ThingsToHit.Ball;

                screenRenderer.DrawScreen(internalState);

                Thread.Sleep(1000/60000);
            }
        }

        //Loop waiting for player input. On a seperate thread so it can be killed when the game over state is
        //reached and it doesn't hang up the game state progression at the ReadKey().
        private void WaitForInput()
        {
            while (true)
            {
                Console.ReadKey(true);
            }
        }
    }
}

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
        public static bool gameRunning = true;

        Ball ball = new Ball();
        Paddle leftPaddle;
        Paddle rightPaddle;
        ThingsToHit[,] internalState;

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

            internalState = new ThingsToHit[Game.Width, Game.Height];
            Renderer screenRenderer = new Renderer();

            //Main gameplay loop. Updates every 1/60th of a second for a 60 hz refresh rate.
            while (gameRunning)
            {
                internalState = new ThingsToHit[Game.Width, Game.Height];
                for (int x = 0; x < Game.Width; x++)
                    internalState[x, 0] = ThingsToHit.Wall;
                for (int x = 0; x < Game.Width; x++)
                    internalState[x, Game.Height - 1] = ThingsToHit.Wall;



                //Place the left paddle into the internalState array
                foreach (Point paddlePosition in leftPaddle.PaddlePosition)
                {
                    internalState[paddlePosition.X, paddlePosition.Y] = ThingsToHit.Paddle;
                }
                //Place the right paddle into the internalState array
                foreach (Point paddlePosition in rightPaddle.PaddlePosition)
                {
                    internalState[paddlePosition.X, paddlePosition.Y] = ThingsToHit.Paddle;
                }
                //Place the ball into the internalState array
                internalState[ball.BallPosition.X, ball.BallPosition.Y] = ThingsToHit.Ball;

                //set the goal fields
                SetGoalLines();

                screenRenderer.DrawScreen(internalState);

                ball.CollisionObjects = internalState;

                Thread.Sleep(1000/60000);
            }

            Console.WriteLine("Round Complete!");
        }

        private void SetGoalLines()
        {
            //left goal
            for (int y = 0; y < Game.Height; y++)
            {
                if (internalState[0, y] != ThingsToHit.Paddle)
                {
                    internalState[0, y] = ThingsToHit.Goal;
                }
            }
            //right goal
            for (int y = 0; y < Game.Height; y++)
            {
                if (internalState[Game.Width - 1, y] != ThingsToHit.Paddle)
                {
                    internalState[Game.Width - 1, y] = ThingsToHit.Goal;
                }
            }
        }
        
        //Loop waiting for player input. On a seperate thread so it can be killed when the game over state is
        //reached and it doesn't hang up the game state progression at the ReadKey().
        private void WaitForInput()
        {
            while (true)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                leftPaddle.PaddleMove(keyPressed);
                rightPaddle.PaddleMove(keyPressed);
            }
        }
    }
}

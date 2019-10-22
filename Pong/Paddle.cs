using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Pong
{
    class Paddle
    {
        private readonly string paddleSide;
        private int paddleCenter;
        public Point[] PaddlePosition { get; } = new Point[5];

        public Paddle(string paddleSide)
        {
            this.paddleSide = paddleSide;
            paddleCenter = Game.Height / 2;
            NewPaddlePosition();    //Set up initial paddle position
        }

        //Set the new paddle position based on the center point
        private void NewPaddlePosition()
        {
            if (paddleSide == "left")
            {
                int arrayPosition = 0;
                for (int i = paddleCenter - 2; i < paddleCenter + 3; i++)
                {
                    PaddlePosition[arrayPosition] = new Point(0, i);
                    arrayPosition++;
                }
            }
            if (paddleSide == "right")
            {
                int arrayPosition = 0;
                for (int i = paddleCenter - 2; i < paddleCenter + 3; i++)
                {
                    PaddlePosition[arrayPosition] = new Point(Game.Height - 1, i);
                    arrayPosition++;
                }
            }
        }

        public void PaddleMove(ConsoleKey keyPressed)
        {
            if (keyPressed == ConsoleKey.UpArrow)
            {
                paddleCenter++;
                NewPaddlePosition();
            }
            if (keyPressed == ConsoleKey.DownArrow)
            {
                paddleCenter--;
                NewPaddlePosition();
            }
        }
    }
}

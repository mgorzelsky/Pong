using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace Pong
{
    class Ball
    {
        private Point ballPosition;
        private int ballDirection;
        Random rnd = new Random();
        private readonly Timer timer = new Timer(150);

        public Ball() 
        {
            ballDirection = rnd.Next(0,4);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }


        public Point BallPosition { get => ballPosition; }
        
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Move();
        }

        private void Move()
        {
            switch (ballDirection)
            {
                case (0): //up-left
                    ballPosition.Offset(-1, 1);
                    break;
                case (1): //down-left
                    ballPosition.Offset(-1, -1);
                    break;
                case (2): //up-right
                    ballPosition.Offset(1, 1);
                    break;
                case (3): //down-right
                    ballPosition.Offset(1, -1);
                    break;
            }
        }
    }
}

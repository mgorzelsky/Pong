using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Timers;

namespace Pong
{
    enum BallDirection { UpLeft, DownLeft, UpRight, DownRight };
    class Ball
    {
        private Point ballPosition = new Point(40, 15);
        private BallDirection ballDirection;
        Random rnd = new Random();
        private readonly Timer timer = new Timer(150);
        private int angle;

        public Ball() 
        {
            ballDirection = (BallDirection)rnd.Next(0, 4);
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
            if (angle % 2 == 0)     //flatter angler
            {
                switch (ballDirection)
                {
                    case (BallDirection.UpLeft): //up-left
                        ballPosition.Offset(-2, 1);
                        if (ballPosition.X < 0)
                            ballPosition.X = 0;
                        break;
                    case (BallDirection.DownLeft): //down-left
                        ballPosition.Offset(-2, -1);
                        if (ballPosition.X < 0)
                            ballPosition.X = 0;
                        break;
                    case (BallDirection.UpRight): //up-right
                        ballPosition.Offset(2, 1);
                        if (ballPosition.X > Game.Width - 1)
                            ballPosition.X = Game.Width - 1;
                        break;
                    case (BallDirection.DownRight): //down-right
                        ballPosition.Offset(2, -1);
                        if (ballPosition.X > Game.Width - 1)
                            ballPosition.X = Game.Width - 1;
                        break;
                }
            }
            else     //sharper angle
            {
                switch (ballDirection)
                {
                    case (BallDirection.UpLeft): //up-left
                        ballPosition.Offset(-1, 1);
                        if (ballPosition.X < 0)
                            ballPosition.X = 0;
                        break;
                    case (BallDirection.DownLeft): //down-left
                        ballPosition.Offset(-1, -1);
                        if (ballPosition.X < 0)
                            ballPosition.X = 0;
                        break;
                    case (BallDirection.UpRight): //up-right
                        ballPosition.Offset(1, 1);
                        if (ballPosition.X > Game.Width - 1)
                            ballPosition.X = Game.Width - 1;
                        break;
                    case (BallDirection.DownRight): //down-right
                        ballPosition.Offset(1, -1);
                        if (ballPosition.X > Game.Width - 1)
                            ballPosition.X = Game.Width - 1;
                        break;
                }
            }
            CollisionCheck();
        }

        public void Bounce(ThingsToHit surface)
        {
            if (surface == ThingsToHit.Paddle)
            {
                switch (ballDirection)
                {
                    case (BallDirection.UpLeft):                  //up-left TO
                        ballDirection = BallDirection.UpRight;    //up-right
                        break;
                    case (BallDirection.DownLeft):                //down-left TO
                        ballDirection = BallDirection.DownRight;  //down-right
                        break;
                    case (BallDirection.UpRight):                 //up-right TO
                        ballDirection = BallDirection.UpLeft;     //up-left
                        break;
                    case (BallDirection.DownRight):               //down-right TO
                        ballDirection = BallDirection.DownLeft;   //down-left
                        break;
                }
                angle = rnd.Next(0, 100);
                //Move();
            }
            if (surface == ThingsToHit.Wall)
            {
                switch (ballDirection)
                {
                    case (BallDirection.UpLeft):                 //up-left TO
                        ballDirection = BallDirection.DownLeft;  //down-left
                        break;
                    case (BallDirection.DownLeft):               //down-left TO
                        ballDirection = BallDirection.UpLeft;    //up-left
                        break;
                    case (BallDirection.UpRight):                 //up-right TO
                        ballDirection = BallDirection.DownRight;  //down-right
                        break;
                    case (BallDirection.DownRight):               //down-right TO
                        ballDirection = BallDirection.UpRight;    //up-right
                        break;
                }
                //Move();
            }
        }
        private void CollisionCheck()
        {
            if (BallPosition.X >= Game.Width - 1 || BallPosition.X <= 0)
                Bounce(ThingsToHit.Paddle);
            if (BallPosition.Y >= Game.Height - 1 || BallPosition.Y <= 0)
                Bounce(ThingsToHit.Wall);
        }
    }
}

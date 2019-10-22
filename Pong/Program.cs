using System;
using System.Threading;

namespace Pong
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(1, 1);
            //Console size must be odd numbers so that when adjusted for off-by-one it is in an even range
            //See Ball.Move()
            Console.SetBufferSize(80, 30);
            Console.SetWindowSize(80, 30);

            Game pongGame = new Game();
            Game.Width = 80;
            Game.Height = 30;
            pongGame.Start();
        }
    }
}

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
            Console.SetBufferSize(81, 31);
            Console.SetWindowSize(81, 31);

            Game pongGame = new Game();
            pongGame.Start();
        }
    }
}

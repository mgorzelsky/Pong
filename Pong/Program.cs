using System;
using System.Threading;

namespace Pong
{
    class Program
    {
        static void Main()
        {
            //Console size must be odd numbers so that when adjusted for off-by-one it is in an even range
            //See Ball.Move()
            int height = 31;
            int width = 81;
            
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(width, height + 1);
            Console.SetWindowSize(width, height + 1);

            Game pongGame = new Game(width, height);
            pongGame.Start();
        }
    }
}

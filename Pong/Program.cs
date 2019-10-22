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
            //Console.SetWindowSize(1, 1);
            //Console.SetBufferSize(81, 31);
            //Console.SetWindowSize(81, 31);

            Game pongGame = new Game();
            Game.Width = 81;
            Game.Height = 31;
            pongGame.Start();
        }
    }
}

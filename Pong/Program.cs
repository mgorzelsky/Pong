using System;
using System.Threading;

namespace Pong
{
    class Program
    {
        //Clear the console and set CursorVisible to false so they do not visually distract.
        //Instantiate the game, set the static variables for the size of game desired. Start the
        //main game loop.
        static void Main()
        {
            Console.Clear();
            Console.CursorVisible = false;

            Game pongGame = new Game(71, 26);
            pongGame.Start();
        }
    }
}

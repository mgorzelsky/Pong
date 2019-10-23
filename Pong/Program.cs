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
            int width = 71;
            int height = 26;

            string pongLogo = @"//==\\  //====\\  ||      ||   //===\\"  + "\a" +
                              @"||  ||  ||    ||  ||\\    ||  //"        + "\a" +
                              @"||==//  ||    ||  ||  \\  ||  ||   ===\" + "\a" +
                              @"||      ||    ||  ||    \\||  \\     //" + "\a" +
                              @"||      \\====//  ||      ||   \\===//"  + "\a";
            string contributers = "Contributers: Michael Gorzelsky";

            Renderer renderer = new Renderer();
            renderer.DrawGenericScreen(pongLogo, width/3, 0);
            renderer.DrawGenericScreen(contributers, width / 3 + 2, height - 1);
            
            
            Thread.Sleep(5000);

            Game pongGame = new Game(width, height);
            pongGame.Start();
        }
    }
}

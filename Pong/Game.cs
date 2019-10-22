using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Pong
{
    public delegate void ThreadStart();
    class Game
    {
        //Main gameplay loop. Updates every 1/60th of a second for a 60 hz refresh rate.
        public void Start()
        {
            Thread inputThread = new Thread(WaitForInput);
            inputThread.Start();
            while (true)
            {
                
                Thread.Sleep(1000/60000);
            }
        }

        private void WaitForInput()
        {
            while (true)
            {
                Console.WriteLine(Console.ReadKey());
            }
        }
    }
}

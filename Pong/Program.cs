﻿using System;
using System.Threading;

namespace Pong
{
    class Program
    {
        static void Main()
        {
            Game pongGame = new Game();
            pongGame.Start();
        }
    }
}
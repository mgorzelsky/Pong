using System;
using System.Collections.Generic;
using System.Text;

namespace Pong
{
    public class Renderer
    {
        public void DrawScreen(ThingsToHit [,] internalState)
        {
            StringBuilder screenAsString = new StringBuilder("", Game.Width * Game.Height);
            char currentCharacter = Convert.ToChar(32);
            for (int y = 0; y < Game.Height; y++)
            {
                for (int x = 0; x < Game.Width; x++)
                {
                    switch (internalState[x, y])
                    {
                        case (ThingsToHit.Nothing):
                            currentCharacter = Convert.ToChar(32);
                            break;
                        case (ThingsToHit.Paddle):
                            currentCharacter = '|';
                            break;
                        case (ThingsToHit.Wall):
                            currentCharacter = '-';
                            break;
                        case (ThingsToHit.Ball):
                            currentCharacter = 'o';
                            break;
                        case (ThingsToHit.Goal):
                            currentCharacter = Convert.ToChar(32);
                            break;
                    }
                    screenAsString.Append(new char[] { currentCharacter });
                }
                screenAsString.Append(Environment.NewLine);
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(screenAsString);
        }
    }
}
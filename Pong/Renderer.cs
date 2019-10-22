using System;
using System.Collections.Generic;
using System.Text;

namespace Pong
{
    public class Renderer
    {
        public void DrawScreen(ThingsToHit [,] internalState, int width, int height)
        {
            StringBuilder screenAsString = new StringBuilder("", width * height);
            char currentCharacter = Convert.ToChar(32);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
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
                    }
                    screenAsString.Append(new char[] { currentCharacter });
                }
                screenAsString.Append(Environment.NewLine);
            }
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(screenAsString);
        }
    }
}
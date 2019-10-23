using System;
using System.Collections.Generic;
using System.Text;

namespace Pong
{
    public class Renderer
    {
        public void DrawScreen(GameItems [,] internalState)
        {
            StringBuilder screenAsString = new StringBuilder("", Game.Width * Game.Height);
            char currentCharacter = Convert.ToChar(32);
            for (int y = 0; y < Game.Height; y++)
            {
                for (int x = 0; x < Game.Width; x++)
                {
                    switch (internalState[x, y])
                    {
                        case (GameItems.Nothing):
                            currentCharacter = Convert.ToChar(32);
                            break;
                        case (GameItems.Paddle):
                            currentCharacter = '|';
                            break;
                        case (GameItems.Wall):
                            currentCharacter = '-';
                            break;
                        case (GameItems.Ball):
                            currentCharacter = 'o';
                            break;
                        case (GameItems.Goal):
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
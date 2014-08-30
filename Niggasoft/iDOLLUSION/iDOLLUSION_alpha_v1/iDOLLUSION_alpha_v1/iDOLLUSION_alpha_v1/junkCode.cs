using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDOLLUSION_alpha_v1
    {
    class junkCode
        {



//Junk code that we need to hold onto for hte future can be stored here with a description of how to use it and what it does. Should let us clean up the other classes



////////// This determines the uint value for the color on the collision map that the mouse is currently hovering over and displays it in the window (top left)
/// Use this when designing collision maps in order to get the uints that need to be checked against.  Not needed otherwise.
/*
            string sColorval = "";
            uint[] myUint = new uint[1];
if (ms.X >= 0 && ms.X < collisionMap.Width && ms.Y >= 0 && ms.Y < collisionMap.Height)  // DISPLAYS color value of collision map
            {
                collisionMap.GetData(0, new Rectangle(ms.X, ms.Y, 1, 1), myUint, 0, 1);
                sColorval = myUint[0].ToString();
            }
            Window.Title = ms.X.ToString() + "," + ms.Y.ToString() + " - " + sColorval;
*/




//Sparkle code for main menu, doesnt work
    /*            int numSparkles = Sparkle.sparkles.Length;
                for (int i = 0; i != numSparkles; i++)
                {
                    Sparkle thisSparkle = Sparkle.sparkles[i];
                    if (thisSparkle != null && !thisSparkle.dead) //handle null when no sparkles are around
                    {
                        thisSparkle.updateLifespan();
                        spriteBatch.Draw(sparkle, thisSparkle.position, Color.White);
                        if (i == numSparkles)
                        {
                            i = 0;
                        }
                    }
                    else
                    {
                        spriteBatch.DrawString(gameFont,  "Not sparkly at all..." , new Vector2(200, 400), Color.Red);
                    }
                }

*/









     

















   }
    }

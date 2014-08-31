using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace iDOLLUSION_alpha_v1
    {
  static  class MouseDetection
        {


static public int click = 0;
static int timeOutTimer = 0;
static int timeOutLimit = 20;
 static bool isTimeOut = false;

/*

       var mouseState = Mouse.GetState();              // use mouseState instead of Mouse.GetState() from here on out
        Point mousePosition = new Point(mouseState.X, mouseState.Y);

*/
 


      public static  bool clicked()
      {
          checkClick();
          if ((Microsoft.Xna.Framework.Input.Mouse.GetState().LeftButton == ButtonState.Pressed) && click == 1)
          {
              click = 0;
              isTimeOut = false;
              timeOutTimer = 0;
              return true;
          }
                    return false;
            }

        private static int checkClick()
        {
            
            if (Microsoft.Xna.Framework.Input.Mouse.GetState().LeftButton == ButtonState.Released)
            {
                click = 1;
                isTimeOut = true;
            }
            return click;
        }

        public static void checkTimeout()
        {
            if (isTimeOut && click > 0)
            {
                timeOutTimer++;
                if (timeOutTimer > timeOutLimit)
                {
                    click = 0;
                    isTimeOut = false;
                    timeOutTimer = 0;
                }
            }
            return;
        }













        }
    }

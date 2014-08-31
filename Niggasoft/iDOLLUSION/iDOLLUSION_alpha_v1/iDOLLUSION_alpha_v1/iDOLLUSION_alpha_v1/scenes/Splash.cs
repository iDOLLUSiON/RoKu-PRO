using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;

namespace iDOLLUSION_alpha_v1.scenes
    {
    class Splash
        {

         int directionSilver = 1;
         int directionGold = 1;

private KeyState ks = new KeyState();

static int splashTimer = 0;



        public static void upDate()
        {
            if (splashTimer == 0)
            {
                            Music.play(Main.techworld);

            }
            if (MouseDetection.clicked() )
            {
                Main.currentScene++;   //Clicking on teh splash proceeds tothe next screen

            }
             splashTimer++;     //Automatically proceed to main menu after a time
                if (splashTimer > 2000)
                {
                    Main.currentScene++;
                    splashTimer = 0;
                    Music.play(Main.edenEffect);
                }

        }



























        }
    }

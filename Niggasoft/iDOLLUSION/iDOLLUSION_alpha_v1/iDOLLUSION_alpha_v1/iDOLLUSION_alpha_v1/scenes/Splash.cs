using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iDOLLUSION_alpha_v1.scenes
    {
    class Splash
        {

         int directionSilver = 1;
         int directionGold = 1;



        public static void upDate()
        {
            if (MouseDetection.clicked())
            {
                Main.currentScene++;   //Clicking on teh splash proceeds tothe next screen

            }
        }



























        }
    }

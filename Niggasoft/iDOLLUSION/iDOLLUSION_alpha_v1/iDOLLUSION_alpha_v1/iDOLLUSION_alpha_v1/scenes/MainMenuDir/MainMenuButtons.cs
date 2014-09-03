using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDOLLUSION_alpha_v1.scenes.MainMenuDir
 {
    class MainMenuButtons : MainMenu
    {


        private enum ButtonTypes
        {
            START,
            EXIT,
            LOOPTOSTART,

        };
       private ButtonTypes buttonType = new ButtonTypes();

        MainMenuButtons(ButtonTypes thisButtonType)
        {
            MainMenu.mainMenuButtons.Add(this);
            buttonType = thisButtonType;
        }



   }
 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace iDOLLUSION_alpha_v1.characters
    {
    class Companies
    {
        private KeyState oldKeyState = new KeyState();


        
        private string companyName;
        Random rnd = new Random();
        private enum CompanySize
        {
            TINY,
            SMALL,
            MEDIUM,
            LARGE
        };
        private CompanySize companySize = CompanySize.TINY;

        private enum Press
        {
            BADPRESS,
            GOODPRESS,
        }

        private List<Idol> companyIdols = new List<Idol>();

        Companies()
        {
            companyName = rnd.Next(300, 999) + " Productions";
            int size = rnd.Next(15);
            if (size < 7) //0-6
            {
                companySize = CompanySize.TINY;
            }
            else if (size < 12) //7-11
            {
                companySize = CompanySize.SMALL;
            }
            else if (size < 15) //12-14
            {
                companySize = CompanySize.MEDIUM;
            }
            else  //15
            {
                companySize = CompanySize.LARGE;
            }

        }

        Companies(string newCompanyName)
        {
            companyName = newCompanyName;
        }





    }
    }

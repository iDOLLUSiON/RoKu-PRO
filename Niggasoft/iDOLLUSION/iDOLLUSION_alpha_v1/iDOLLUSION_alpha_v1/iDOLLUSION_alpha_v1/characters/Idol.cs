﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace iDOLLUSION_alpha_v1.characters
    {
        internal class Idol
        {

            private string idolName;
            private Regions.Region homeRegion;
            private int age;
            private bool isUnitMember;
            //   private Units.Unit unit;
            private int determination;
            private int unity;


//Level stuff
            private enum IdolLevel
            {
                E = 1,
                D = 2,
                C = 3,
                B = 4,
                A = 5
            };

            private IdolLevel idolLevel = IdolLevel.E;
            private int idolLevelInt = 1;
            private int idolPoints = 0;
            private int idolPointsNeeded = 500;

            private const String E = "E-Rank";
            private const String D = "D-Rank";
            private const String C = "C-Rank";
            private const String B = "B-Rank";
            private const String A = "A-Rank";
            private String idolLevelText = E;

            public void updateIdolLevel()
            {
                idolLevelInt = (int) idolLevel; //cast enum idolLevel to an integer value
                idolPointsNeeded = 1000*idolLevelInt;

                if (idolPoints > idolPointsNeeded)
                {
                    idolLevel++;
                    idolPoints -= idolPointsNeeded;
                    idolPointsNeeded = 500*idolLevelInt;

                }
                //update Text
                switch (idolLevel)
                {

                    case IdolLevel.E:
                        idolLevelText = E;
                        break;
                    case IdolLevel.D:
                        idolLevelText = D;
                        break;
                    case IdolLevel.C:
                        idolLevelText = C;
                        break;
                    case IdolLevel.B:
                        idolLevelText = B;
                        break;
                    case IdolLevel.A:
                        idolLevelText = A;
                        break;


                }

                return;
            }



//CONSTRUCTOR

            public Idol(string name, Regions.Region home)
            {

            }








//PUBLIC METHODS


            public int getUnity(Idol idol)
            {
                return this.unity;
            }




    }
    }

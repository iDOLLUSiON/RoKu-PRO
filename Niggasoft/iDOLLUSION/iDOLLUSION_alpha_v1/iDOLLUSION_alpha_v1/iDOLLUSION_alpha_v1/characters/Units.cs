using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;

namespace iDOLLUSION_alpha_v1.characters
    {
        internal class Units
        {


//Lists
            private List<Idol> unitMembers = new List<Idol>(); //list of idols in each unit
            //static lists
            private static List<Units> unitList = new List<Units>(); //list of all units
            private static List<Idol> idolsInUnits = new List<Idol>(); //list of all idol in units, to prevent "double booking" problems down the line
            private static List<Idol> unitLeaders = new List<Idol>(); //List of all unit leaders
//Unit variables
            private string unitName; //the name of hte unit as a whole eg AKB48
            private Regions.Region homeRegion; //the units home region, different than idols individual
            private int unitUnity; // how cohesive hte unit is, average of all member's unity scores.
            private Idol unitLeader; //The leader of the unit.  Is always the first idol added


            public Units(Idol idol1, Idol idol2)
            {
            //check for problems
                if (idolsInUnits.Contains(idol1) || idolsInUnits.Contains(idol2))
                {
                    return;  //if the idols are already in units, then no new unit can be made with them
                }
        
                string newUnitName = Microsoft.VisualBasic.Interaction.InputBox("Input Unit Name",
                    "Create a New Duo Unit:", "", 640, 360); //weird resharper formatting, sorry.   But basically this just makes a popup textbox. Imported from VB
                    //This all works!  The box itself needs to be prettied up tho!
                Console.WriteLine(newUnitName); //for testing the text box
                this.unitName = newUnitName;
                    //using "this" is unecessary but I prefer it for clarity sake.  The compiler will remove it
                this.unitMembers.Add(idol1);
                this.unitMembers.Add(idol2);
                this.unitLeader = idol1; //set idol1 as unitleader of this unit
                this.unitUnity = generateUnityValue(unitMembers);
                //static
                unitLeaders.Add(idol1); //add "idol1" to the list of unitleaders
                idolsInUnits.Add(idol1);
                idolsInUnits.Add(idol2);            

            }

            public Units(Idol idol1, Idol idol2, Idol idol3)
            {
                if (idolsInUnits.Contains(idol1) || idolsInUnits.Contains(idol2) || idolsInUnits.Contains(idol3))
                {
                    return;
                }
                string newUnitName = Microsoft.VisualBasic.Interaction.InputBox("Input Unit Name",
                    "Create a New Trio Unit:", "", 640, 360);
                    //This all works!  The box itself needs to be prettied up tho!
                Console.WriteLine(newUnitName); //for testing the text box
                this.unitName = newUnitName; //C# has no way to add multiple 
                this.unitMembers.Add(idol1);
                this.unitMembers.Add(idol2);
                this.unitMembers.Add(idol3);
                this.unitLeader = idol1; //set idol1 as unitleader of this unit
                this.unitUnity = generateUnityValue(unitMembers);
             //static
               unitLeaders.Add(idol1);
                idolsInUnits.Add(idol1);
                idolsInUnits.Add(idol2);
                idolsInUnits.Add(idol3);
            }

            public Units(Idol idol1, Idol idol2, Idol idol3, Idol idol4)
            {
                if (idolsInUnits.Contains(idol1) || idolsInUnits.Contains(idol2) || idolsInUnits.Contains(idol3) || idolsInUnits.Contains(idol4))
                {
                    return;
                }
                string newUnitName = Microsoft.VisualBasic.Interaction.InputBox("Input Unit Name",
                    "Create a New 4-Member Unit:", "", 640, 360);
                    //This all works!  The box itself needs to be prettied up tho!
                Console.WriteLine(newUnitName); //for testing the text box
                this.unitName = newUnitName;
                this.unitMembers.Add(idol1);
                this.unitMembers.Add(idol2);
                this.unitMembers.Add(idol3);
                this.unitMembers.Add(idol4);
                this.unitLeader = idol1; //set idol1 as unitleader of this unit
                this.unitUnity = generateUnityValue(unitMembers); //Generates unity value by taking the unity value of all members of the list, averaging them, and then casting to int.
                //static
                unitLeaders.Add(idol1);
                idolsInUnits.Add(idol1);
                idolsInUnits.Add(idol2);
                idolsInUnits.Add(idol3);
                idolsInUnits.Add(idol4);
            }



//Private methods
     private int generateUnityValue(List<Idol> memberlist)
            {
                List<int> unityVals = new List<int>(); //declares a new list of type int to contain each idols unity value
                foreach (Idol idol in memberlist)  //gets the unity value of each idol
                { 
                  unityVals.Add(idol.getUnity(idol));   //adds each idols unity value to the list.  Lists dynamically resize their arrays, so no risk of out of bounds error.
                }
                int unityValsInt = (int)unityVals.Average(); //casts double to int
                return unityValsInt;

            } 


//PUBLIC METHODS

            public List<Idol> getUnitMembers(Units unit)
            {
                return this.unitMembers;
            }

           public bool isUnitLeader(Units unit, Idol idol)
            {
               if (idol == this.unitLeader)
               {
                   return true;
               }
               return false;
            }


          public bool isUnitMember(Units unit, Idol idol)
            {
               if (this.unitMembers.Contains(idol))
               {
                   return true;
               }
               return false;
            }
        


    } //class
 } //namespace

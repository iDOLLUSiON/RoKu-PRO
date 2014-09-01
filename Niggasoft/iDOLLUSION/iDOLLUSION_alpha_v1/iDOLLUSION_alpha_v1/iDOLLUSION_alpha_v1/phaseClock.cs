using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Microsoft.Xna.Framework;

namespace iDOLLUSION_alpha_v1
{
    internal static class phaseClock
    {
//this clock decides when events are possible, what time of day it is, etc.
//NEVER PROCEED FROM EVENING -> MORNING OR SUNDAY -> MONDAY.  ALWAYS USE DAYLIMIT AND TIMELIMIT AND CALL upDate(); !!!!

        public enum Time //Split the day into 4 timezones, TimeLimit is used only to proceed back to Morning
        {
            Morning = 1,
            Noon,
            Afternoon,
            Evening,
            TimeLimit //automatically rolls over to morning
        };

        private static Time currentTime = Time.Morning;
        private static Time timeLimit = Time.TimeLimit;

        public enum Day
        {
            Monday = 1,
            Tuesday=2,
            Wednesday=3,
            Thursday=4,
            Friday=5,
            Saturday=6,
            Sunday=7,
            DayLimit=8 //automatically rolls over to Monday
        };

        private static Day today = Day.Monday;
        private static Day dayLimit = Day.DayLimit;
        private static int daysElapsed = 0;
        private static int weeksElapsed = 0;
        private static int currentWeek = 0;
        private static int xCoord;
        public static int yCoord = 45;



        public static void upDate() //call after any time change
        {
            if (currentTime == timeLimit) //Go from night to morning and mark day as elapsed
            {
                daysElapsed++;
                currentTime = Time.Morning;
                today++;
            }
            if (today == dayLimit) //Go from sunday to monday
            {
                today = Day.Monday;
            }
            if (daysElapsed > 6) //Convert days to weeks
            {
                weeksElapsed++;
                daysElapsed -= 7;
            }
            currentWeek = weeksElapsed + 1;
            return;

        }


        public static bool isWeekend()
        {
            return (today > Day.Friday);
        }

        public static bool isWeekday()
        {
            return !isWeekend();
        }

        public static void spendTime() //automatically passes 1 phase of the day
        {
            currentTime++;
            upDate();
        }

        public static void spendTime(int timeSpent)
            //use to pass multiple phases of the day, be sure to check for exceptions
        {
            currentTime += timeSpent;
            upDate();
        }

        public static void spendDay() //progresses to the next morning regardless of day phase
        {
            currentTime = Time.TimeLimit;
            upDate();
        }

        public static Day getDay()
        {
            return today;
        }

        public static Time getTime()
        {
            return currentTime;
        }


        public static int getSelectionCoord()
        {
            switch (today) //X
            {
                case phaseClock.Day.Monday:
                {
                    xCoord = 110;
                    break;
                }
                case phaseClock.Day.Tuesday:
                {
                    xCoord = 265;
                    break;
                }
                case phaseClock.Day.Wednesday:
                {
                    xCoord = 415;
                    break;
                }
                case phaseClock.Day.Thursday:
                {
                    xCoord = 562;
                    break;
                }
                case phaseClock.Day.Friday:
                {
                    xCoord = 715;
                    break;
                }
                case phaseClock.Day.Saturday:
                {
                    xCoord = 860;
                    break;
                }
                case phaseClock.Day.Sunday:
                {
                    xCoord = 1012;
                    break;
                }
            }
            return xCoord;

        }//end of switch

       public static string getWeek()
       {
           string thisWeek = currentWeek+"";
           return thisWeek;
       }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace iDOLLUSION_alpha_v1
{
    internal static class phaseClock
    {
//this clock decides when events are possible, what time of day it is, etc.
        public enum Time
        {
            Morning = 1,
            Noon,
            Afternoon,
            Evening,
            TimeLimit
        };
        
        private static Time currentTime = Time.Morning;
        private static Time timeLimit = Time.TimeLimit;

        public enum Day
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
            DayLimit
        };

        private static Day today = Day.Monday;
        private static Day dayLimit = Day.DayLimit;



       private static void upDate() //call after any time change
        {
           if (currentTime == timeLimit) //go from night to morning
           {
               currentTime = Time.Morning;
               today++;
           }
           if (today == dayLimit)  //go from sunday to monday
           {
               today = Day.Monday;
           }
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

        public static void spendTime()
        {
            currentTime++;
            upDate();
        }

        public static void spendTime(int timeSpent)
        {
            currentTime +=  timeSpent;
            upDate();
        }

        public static void spendDay()
        {
            currentTime = Time.Morning;
            today++;
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


    }
}
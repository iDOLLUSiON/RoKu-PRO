using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;

namespace iDOLLUSION_alpha_v1
    {
    class Events
    {
        private phaseClock.Day day; //when the event is
        private phaseClock.Time time;

        private string eventText; //text for schedule
        public static List<Events> eventList = new List<Events>();
        public int xCoord;
        public int yCoord;
        public Vector2 eCoords = new Vector2();


        public enum EventType
        {
            AUDITION,
            LIVE,
            REHEARSAL
        };
        private EventType eventType;


      public  Events(phaseClock.Day eDay, phaseClock.Time eTime, EventType eEventType)
        {
            day = eDay;
            time = eTime;
            eventType = eEventType;
          eventList.Add(this);
          switch (eEventType) //set appropriate text based on event type. Read from xml in future
              {
              case EventType.AUDITION:
                      {
                      eventText = "Audition";
                      break;
                      }
              case EventType.REHEARSAL:
                  {
                      eventText = "Rehearsal";
                      break;

                  }
            default:
                  {
                      eventText = "Live!";
                      break;
                  }

              }//end of switch
//Determine x and y coordinates
          switch (eDay)
              {
              case phaseClock.Day.Monday:
                      {
                      xCoord = 75;
                      break;
                      }

              default:
                  {
                      xCoord = 500;
                      break;
                  }
              } //end of switch

          switch (eTime)
              {
              case phaseClock.Time.Afternoon:
                      {
                      yCoord = 370;
                      break;
                      }

              default:
                  {
                      yCoord = 500;
                      break;
                  }
              } //end of switch

            eCoords.X = xCoord;
            eCoords.Y = yCoord;

        }

    }
    }

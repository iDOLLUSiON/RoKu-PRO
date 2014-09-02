using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using iDOLLUSION_alpha_v1.characters;
using Microsoft.Xna.Framework;

namespace iDOLLUSION_alpha_v1
    {
    class Events
    {
        private phaseClock.Day day; //when the event is
        private phaseClock.Time time;

        public string eventText; //text for schedule
        public static List<Events> eventList = new List<Events>();
        private int xCoord;
        private int yCoord;
        public Vector2 eCoords = new Vector2();
        public Vector2 selectionCoords = new Vector2();
        private List<Idol> participatingIdols = new List<Idol>();
        private List<Units> participatingUnits = new List<Units>();

        


        public enum EventType
        {
            AUDITION,
            LIVE,
            REHEARSAL
        };
        private EventType eventType;


      public  Events(phaseClock.Day eDay, phaseClock.Time eTime, EventType eEventType, Units participatingUnit)
        {
            day = eDay;
            time = eTime;
            participatingUnits.Add(participatingUnit);
          foreach (Units unit in participatingUnits)
          {
              participatingIdols.AddRange(unit.getUnitMembers(unit)); //add all members of participating unit to particpating idols
          }
            
            eventType = eEventType;
          eventList.Add(this);
          switch (eEventType) //set appropriate text based on event type. Read from xml in future
              {
              case EventType.AUDITION:
                      {
                      eventText = "Audition: "+ participatingUnits;
                      break;
                      }
              case EventType.REHEARSAL:
                  {
                      eventText = "Rehearsal: "+ participatingUnits;
                      break;

                  }
            default:
                  {
                      eventText = "Live! - "+ participatingUnits;
                      break;
                  }

              }//end of switch
//Determine x and y coordinates
          switch (eDay) //X
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

              default:
                  {
                      xCoord = 500;
                      break;
                  }
              } //end of switch

          switch (eTime) //Y
              {            
              case phaseClock.Time.Morning:
                      {
                      yCoord = 175;
                      break;
                      }
              case phaseClock.Time.Noon:
                      {
                      yCoord = 325;
                      break;
                      }
              case phaseClock.Time.Afternoon:
                      {
                      yCoord = 465;
                      break;
                      }
              case phaseClock.Time.Evening:
                      {
                      yCoord = 610;
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
                      eventText = "Live!:" ;
                      break;
                  }

              }//end of switch
//Determine x and y coordinates
          switch (eDay) //X
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

              default:
                  {
                      xCoord = 500;
                      break;
                  }
              } //end of switch

          switch (eTime) //Y
              {            
              case phaseClock.Time.Morning:
                      {
                      yCoord = 175;
                      break;
                      }
              case phaseClock.Time.Noon:
                      {
                      yCoord = 325;
                      break;
                      }
              case phaseClock.Time.Afternoon:
                      {
                      yCoord = 465;
                      break;
                      }
              case phaseClock.Time.Evening:
                      {
                      yCoord = 610;
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

//PUBLIC METHODS
        public string getEventText()
        {
            return eventText;
        }

        }//end of class
    }

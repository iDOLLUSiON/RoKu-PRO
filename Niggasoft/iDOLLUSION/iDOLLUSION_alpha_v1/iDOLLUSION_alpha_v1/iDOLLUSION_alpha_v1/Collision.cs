using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace iDOLLUSION_alpha_v1
    {
    static class Collision
    {

        private const uint passable = 4280744959,
            impassable = 4278190080,
            building1 = 4294901760,
            building2 = 4278190335;

       private  enum CollisionTypes : uint
       {
        Passable = 4280744959,
        Impassble = 4278190080,
        Building1 = 4294901760,
        Building2 = 4278190335,
       };

       static CollisionTypes currentCollision = new CollisionTypes();





        public static void processMovement(Vector2 shift )
        {
            if (shift.X == 0 && shift.Y == 0) //redundant
            {
                return;
            }  
             else
            {
            float futureFloatX, futureFloatY;
                int futureX, futureY;
            futureFloatX = Main.getProducer("X") + shift.X;
            futureFloatY = Main.getProducer("Y") + shift.Y;
                if (futureFloatX > 1250 || futureFloatX < 0 || futureFloatY > 690 || futureFloatY < 0)  //Handle out of bounds errors
                {
                    return;
                }

                futureX = (int) futureFloatX;
                futureY = (int) futureFloatY;
                if (checkCollision(futureX, futureY))
                {
                    Main.setProducerLocation(futureX, futureY);
                }
                else
                {
                    return;  //This entire else statement is uneccessary, but makes it easier to follow.  All variables are self-resetting.
                }
            }
        }



    public static bool checkCollision(int  x, int y)
       {
uint currentArea = 0; 
uint[] myUint = new uint[1];
            if (x >= 0 && x < Main.collisionMap.Width && y >= 0 && y < Main.collisionMap.Height)
            {
                Main.collisionMap.GetData(0, new Rectangle(x+25, y+25, 1, 1), myUint, 0, 1);
                currentArea = myUint[0];
            }
        switch (currentArea)
        {
            case (passable):
            {
                currentCollision = CollisionTypes.Passable;
                processCollision();
                return(true);
            }
            case(impassable):
            {
                currentCollision = CollisionTypes.Impassble;
                processCollision();
                return(false);
            }
            case(building1):
            {
                currentCollision = CollisionTypes.Building1;
                processCollision();
                return(true);
            }
            case(building2):
            {
                currentCollision = CollisionTypes.Building2;
                processCollision();
                return(true);
            }
            default:
            {
                return(true);
            }
        }


       }


      private static void  processCollision() //This doesn't need to be a seperate method, but I think it's neater, and performance is negligible since its in one class
      {
      switch (currentCollision)
          {
          case CollisionTypes.Building1:
              {
                  break;
              }
          default:
                  {
                  return;
                  }
          }
          return;
      }

        public static void resetProducerLocation()
        {
            Main.setProducerLocation(570, 660);
            return;
        }



    }
/*
        static class CollisionHandling
        {








            switch (currentArea)  //Switch block for checking collisions
                {
                case chinpo: // If in contact with chinpo building
                    {
                        currentLocation = Location.Splash;  //returns the player to splash screen and resets position.  Used for testing, will be removed later
          producerX = 570;
          producerY = 660;
                        break;
                    }
                case grass:    //Player should not be able to enter grass
                        // add rebound code
                        break;
                case loli:
                        break;

            default:
                        break;
                }
            
        }*/
 }

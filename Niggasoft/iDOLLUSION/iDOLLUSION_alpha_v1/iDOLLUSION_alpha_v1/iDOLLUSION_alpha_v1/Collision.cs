using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace iDOLLUSION_alpha_v1
    {
    static class Collision
    {

        private const uint
             passable = 4280744959,
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
//movement won't cause exception
                futureX = (int) futureFloatX; //cast to int
                futureY = (int) futureFloatY;
                if (checkCollision(futureX, futureY))  //check if coords are passable or not
                {
                    Main.setProducerLocation(futureX, futureY);
                    futureFloatX = 0;
                    futureFloatY = 0;
                }

            }
        }



    public static bool checkCollision(int  x, int y)
       {
uint currentArea = 0; 
uint[] myUint = new uint[1];
        if (Main.currentScene == Main.Scene.MainMap)
        {
            if (x >= 0 && x < ImageLoader.collisionMap.Width && y >= 0 && y < ImageLoader.collisionMap.Height)
            {
                ImageLoader.collisionMap.GetData(0, new Rectangle(x + 25, y + 25, 1, 1), myUint, 0, 1);
                currentArea = myUint[0];
            }
        }
        else if (Main.currentScene == Main.Scene.Office)
        {
            if (x >= 0 && x < ImageLoader.officeCollisionMap.Width && y >= 0 && y < ImageLoader.officeCollisionMap.Height)
            {
                ImageLoader.officeCollisionMap.GetData(0, new Rectangle(x + 25, y + 25, 1, 1), myUint, 0, 1);
                currentArea = myUint[0];
            }
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


        private static void processCollision()
            //This doesn't need to be a seperate method, but I think it's neater, and performance is negligible since its in one class
        {
            switch (currentCollision)
            {
                case CollisionTypes.Building1:
                {
                    setScene(Main.Scene.Office);
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

        public static void setScene(Main.Scene scene)
        {
            resetProducerLocation();
            if (scene == Main.Scene.Office)
            {
                Main.setProducerLocation(860,676);
            }
            Main.currentScene = scene;
        }


}

 }

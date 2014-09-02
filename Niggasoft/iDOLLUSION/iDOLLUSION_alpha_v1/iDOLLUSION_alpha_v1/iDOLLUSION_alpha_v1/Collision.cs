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
            passable = 0,
            black = 4278190080,
            green = 4278255360,
            orange = 4278217471,
            yellow = 4278245631,
            blue = 4294901760,
            red = 4278190335;

       private  enum CollisionTypes : uint
       {
        Passable = passable,
        Impassable = black,
        Blue = blue,
        Red = red,
        Green = green,
        Yellow = yellow,
        Orange = orange
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
        if (Main.currentScene == Main.Scene.MainMap)  //each scene needs a loop with renames ofr its own collision map
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
        else if (Main.currentScene == Main.Scene.Office)
        {
            if (x >= 0 && x < ImageLoader.testZone.Width && y >= 0 && y < ImageLoader.testZone.Height)
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
            case(black):
            {
                currentCollision = CollisionTypes.Impassable;
                processCollision();
                return(false);
            }
            case(yellow):
            {
                currentCollision = CollisionTypes.Yellow;
                processCollision();
                return(true);
            }
            case(orange):
            {
                currentCollision = CollisionTypes.Orange;
                processCollision();
                return(true);
            }
            case(green):
            {
                currentCollision = CollisionTypes.Green;
                processCollision();
                return(true);
            }
            case(red):
            {
                currentCollision = CollisionTypes.Red;
                processCollision();
                return(true);
            }
            case(blue):
            {
                currentCollision = CollisionTypes.Blue;
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
            switch (Main.currentScene)
            {
                case Main.Scene.Home:
                {
                    switch (currentCollision)
                    {
                        case (CollisionTypes.Passable):
                        {
                            break;
                        }
                        case (CollisionTypes.Impassable):
                        {
                            break;
                        }
                        case (CollisionTypes.Blue):
                        {
                            break;
                        }
                        case (CollisionTypes.Red):
                        {
                            break;
                        }   
                        case (CollisionTypes.Green):
                        {
                            break;
                        }
                        case (CollisionTypes.Orange):
                        {
                            break;
                        }
                        case (CollisionTypes.Yellow):
                        {
                            break;
                        }

                    }
                    break;
                }// end
                case Main.Scene.Inbox:
                {
                    switch (currentCollision)
                    {
                        case (CollisionTypes.Passable):
                        {
                            break;
                        }
                        case (CollisionTypes.Impassable):
                        {
                            break;
                        }
                        case (CollisionTypes.Blue):
                        {
                            break;
                        }
                        case (CollisionTypes.Red):
                        {
                            break;
                        }   
                        case (CollisionTypes.Green):
                        {
                            break;
                        }
                        case (CollisionTypes.Orange):
                        {
                            break;
                        }
                        case (CollisionTypes.Yellow):
                        {
                            break;
                        }

                    }
                    break;
                }// end
                case Main.Scene.MainMap:
                {
                    switch (currentCollision)
                    {
                        case (CollisionTypes.Passable):
                        {
                            break;
                        }
                        case (CollisionTypes.Impassable):
                        {
                            break;
                        }
                        case (CollisionTypes.Blue):
                        {
                            break;
                        }
                        case (CollisionTypes.Red):
                        {
                            break;
                        }   
                        case (CollisionTypes.Green):
                        {
                            break;
                        }
                        case (CollisionTypes.Orange):
                        {
                            break;
                        }
                        case (CollisionTypes.Yellow):
                        {
                            break;
                        }

                    }
                    break;
                }// end
                case Main.Scene.Office:
                {
                    switch (currentCollision)
                    {
                        case (CollisionTypes.Passable):
                        {
                            break;
                        }
                        case (CollisionTypes.Impassable):
                        {
                            break;
                        }
                        case (CollisionTypes.Blue):
                        {
                            break;
                        }
                        case (CollisionTypes.Red):
                        {
                            break;
                        }   
                        case (CollisionTypes.Green):
                        {
                            break;
                        }
                        case (CollisionTypes.Orange):
                        {
                            break;
                        }
                        case (CollisionTypes.Yellow):
                        {
                            break;
                        }

                    }
                    break;
                }// end
                case Main.Scene.Schedule:
                {
                    switch (currentCollision)
                    {
                        case (CollisionTypes.Passable):
                        {
                            break;
                        }
                        case (CollisionTypes.Impassable):
                        {
                            break;
                        }
                        case (CollisionTypes.Blue):
                        {
                            break;
                        }
                        case (CollisionTypes.Red):
                        {
                            break;
                        }   
                        case (CollisionTypes.Green):
                        {
                            break;
                        }
                        case (CollisionTypes.Orange):
                        {
                            break;
                        }
                        case (CollisionTypes.Yellow):
                        {
                            break;
                        }

                    }
                    break;
                }// end
                case Main.Scene.Studio:
                {
                    switch (currentCollision)
                    {
                        case (CollisionTypes.Passable):
                        {
                            break;
                        }
                        case (CollisionTypes.Impassable):
                        {
                            break;
                        }
                        case (CollisionTypes.Blue):
                        {
                            break;
                        }
                        case (CollisionTypes.Red):
                        {
                            break;
                        }   
                        case (CollisionTypes.Green):
                        {
                            break;
                        }
                        case (CollisionTypes.Orange):
                        {
                            break;
                        }
                        case (CollisionTypes.Yellow):
                        {
                            break;
                        }

                    }
                    break;
                }// end
                case Main.Scene.Splash:
                {
                    switch (currentCollision)
                    {
                        case (CollisionTypes.Passable):
                        {
                            break;
                        }
                        case (CollisionTypes.Impassable):
                        {
                            break;
                        }
                        case (CollisionTypes.Blue):
                        {
                            break;
                        }
                        case (CollisionTypes.Red):
                        {
                            break;
                        }   
                        case (CollisionTypes.Green):
                        {
                            break;
                        }
                        case (CollisionTypes.Orange):
                        {
                            break;
                        }
                        case (CollisionTypes.Yellow):
                        {
                            break;
                        }

                    }
                    break;
                }// end
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
            if (scene == Main.Scene.Office)
            {
                Main.setProducerLocation(860,676);
            }
            Main.currentScene = scene;
        }


}

 }

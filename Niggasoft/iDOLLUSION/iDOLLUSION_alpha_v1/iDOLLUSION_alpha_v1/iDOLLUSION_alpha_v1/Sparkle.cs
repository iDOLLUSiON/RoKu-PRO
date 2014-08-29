using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace iDOLLUSION_alpha_v1
    {
   public class Sparkle
   {
       public Vector2 position ;
       protected int lifespan = 300;
       protected int lifespanTimer = 0;
       public bool dead = false;
       public int sparkleState = 1;
       protected int sparkleTimer = 0;
       protected int sparkleLimit = 70;
        
       public void updateLifespan()
       {
           if (dead)
           {
               return;
           }
           sparkleTimer++;
if (sparkleTimer > sparkleLimit)
{
    sparkleTimer = 0;
    sparkleState *= -1;
    sparkleLimit -= 5;
}  
          lifespanTimer++;
          if (lifespanTimer > lifespan)
           {
               dead = true;
           }

       }

//CONSTRUCTORS
       public Sparkle()
       {
           int x = 0;
            Random rnd = new Random();
           if (rnd.Next(0,2) == 0)  //lower bound is inclusive, upper is exclusive
           {
                           x = rnd.Next(25, 380);
           }
           else
           {
                           x = rnd.Next(900, 1250);
           }

           int y = rnd.Next(0, 355);
           position.X = x;
           position.Y = y;
       }

   }
    }

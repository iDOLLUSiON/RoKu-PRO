using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace iDOLLUSION_alpha_v1
    {
   public class Sparkle
   {
       private SpriteBatch spriteBatch;
       public Vector2 position ;
       protected int lifespan = 3000;
       protected int lifespanTimer = 0;
       public bool dead = false;
       public int sparkleState = 1;
       protected int sparkleTimer = 0;
       protected int sparkleLimit = 700;
      public static Sparkle[] sparkles = new Sparkle[20];
         int i = 0;

        
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

           int y = rnd.Next(0, 335);
           position.X = x;
           position.Y = y;
       }

   }
    }

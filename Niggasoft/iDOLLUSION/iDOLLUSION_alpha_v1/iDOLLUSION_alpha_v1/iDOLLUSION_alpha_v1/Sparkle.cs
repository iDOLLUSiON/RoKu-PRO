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
   
   public static Sparkle[] sparkles = new Sparkle[20]; //array containing all isntances of sparkle
         int i = 0;

        
       public void updateLifespan()
       {
           if (dead)
           {
               return;
           }
 sparkleTimer++;
if (sparkleTimer > sparkleLimit) //this will be used to swap colors periodically
{
    sparkleTimer = 0;
    sparkleState *= -1;
    sparkleLimit -= 5;
}  
          lifespanTimer++; //when lifespan is met, declare sparkle dead and replace it with one in a different, random location
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
           if (rnd.Next(0,2) == 0)  //lower bound is inclusive, upper is exclusive.  Determines a random position above hte horizon and to the sides of hte sun for a new sparkle
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

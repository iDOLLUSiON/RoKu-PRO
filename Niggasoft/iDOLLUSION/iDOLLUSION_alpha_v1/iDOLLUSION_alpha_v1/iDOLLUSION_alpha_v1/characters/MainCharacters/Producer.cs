using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDOLLUSION_alpha_v1.characters
    {
    class Producer : MainCharacter
        {
//This class just contains stats for PRODUCERSAN(!)

       public  enum ProducerLevel 
       {
        Novice=1,
        Rookie=2,
        Average=3,
        Pro=4,
        Master=5
       };

 private ProducerLevel producerLevel = ProducerLevel.Novice;
        private int producerLevelInt = 1;
        private int producerPoints = 0;
        private int producerPointsNeeded = 500;

 const String Novice = "Novice";
 const String Rookie  = "Rookie";
 const String Average  = "Average";
 const String Pro  = "Pro";
 const String Master  = "Master";
 private String producerLevelText = Novice;

     public void upDateProducerLevel()
     {
         producerPointsNeeded = 500*producerLevelInt;

         if (producerPoints > producerPointsNeeded)
         {
             producerLevel++;
             producerPoints -= producerPointsNeeded;
              producerPointsNeeded = 500*producerLevelInt;

         }
         //update Text
         switch (producerLevel)
         {

case ProducerLevel.Novice:
                 producerLevelText = Novice;
                 break;
case ProducerLevel.Rookie:
                 producerLevelText = Rookie;
                 break;
case ProducerLevel.Average:
                 producerLevelText = Average;
                 break;
case ProducerLevel.Pro:
                 producerLevelText = Pro;
                 break;
case ProducerLevel.Master:
                 producerLevelText = Master;
                 break;
         }

         return;
     }


   










        }



    }

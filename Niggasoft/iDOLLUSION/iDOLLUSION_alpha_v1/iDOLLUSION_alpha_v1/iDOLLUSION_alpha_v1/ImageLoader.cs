using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace iDOLLUSION_alpha_v1
{
    class ImageLoader
    {
        public static Texture2D background, splash, testZone, testZoneCollision, schedule, office, officeCollisionMap, silverButton, goldButton, silverButtonR, goldButtonR, mouseIcon, selectionMarker, mainmenu, button, sparkle, characterSelection, characterSelected, characterUnselected, mainMap, collisionMap, producer;
        public ImageLoader(ContentManager content)
        {
            content.RootDirectory = "Content";
            silverButton = content.Load<Texture2D>("sprites/silverArrow");
            button = content.Load<Texture2D>("sprites/button");
            goldButton = content.Load<Texture2D>("sprites/goldenArrow");
            silverButtonR = content.Load<Texture2D>("sprites/silverArrowReversed");
            goldButtonR = content.Load<Texture2D>("sprites/goldenArrowReversed");
            sparkle = content.Load<Texture2D>("sprites/goldButton");
            characterSelection = content.Load<Texture2D>("images/characterSelection");
            characterSelected = content.Load<Texture2D>("sprites/characterSelected");
            characterUnselected = content.Load<Texture2D>("sprites/characterUnselected");
            background = content.Load<Texture2D>("images/background");
            mainmenu = content.Load<Texture2D>("images/mainmenu");
            splash = content.Load<Texture2D>("images/splash");
            mouseIcon = content.Load<Texture2D>("sprites/mouseIcon");
            collisionMap = content.Load<Texture2D>("images/mainMap/collisionMap");
            mainMap = content.Load<Texture2D>("images/mainMap/mainMap");
            officeCollisionMap = content.Load<Texture2D>("images/office/officeCollisionMap");
            office = content.Load<Texture2D>("images/office/office");
            producer = content.Load<Texture2D>("images/characters/producer");
            schedule = content.Load<Texture2D>("images/schedule/schedule");
            selectionMarker = content.Load<Texture2D>("images/schedule/selectionMarker");
            testZone = content.Load<Texture2D>("images/testZone");
            testZoneCollision = content.Load<Texture2D>("images/testZone");

                
        }
    }
}
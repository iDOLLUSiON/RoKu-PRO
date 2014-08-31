using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace iDOLLUSION_alpha_v1
{
    class ImageLoader
    {
        Content.RootDirectory = "Content";
        public static  Texture2D background, splash, schedule, silverButton, goldButton, silverButtonR, goldButtonR, mouseIcon, mainmenu, button, sparkle, characterSelection, characterSelected, characterUnselected, mainMap, collisionMap, producer;
        private void loadEveryFuckingImage()
        {
            silverButton = Content.Load<Texture2D>("sprites/silverArrow");
            button = Content.Load<Texture2D>("sprites/button");
            goldButton = Content.Load<Texture2D>("sprites/goldenArrow");
            silverButtonR = Content.Load<Texture2D>("sprites/silverArrowReversed");
            goldButtonR = Content.Load<Texture2D>("sprites/goldenArrowReversed");
            sparkle = Content.Load<Texture2D>("sprites/goldButton");
            characterSelection = Content.Load<Texture2D>("images/characterSelection");
            characterSelected = Content.Load<Texture2D>("sprites/characterSelected");
            characterUnselected = Content.Load<Texture2D>("sprites/characterUnselected");
            background = Content.Load<Texture2D>("images/background");
            mainmenu = Content.Load<Texture2D>("images/mainmenu");
            splash = Content.Load<Texture2D>("images/splash");
            mouseIcon = Content.Load<Texture2D>("sprites/mouseIcon");
            collisionMap = Content.Load<Texture2D>("images/mainMap/collisionMap");
            mainMap = Content.Load<Texture2D>("images/mainMap/mainMap");
            producer = Content.Load<Texture2D>("images/characters/producer");
            schedule = Content.Load<Texture2D>("images/schedule/schedule");
        }
    }
}
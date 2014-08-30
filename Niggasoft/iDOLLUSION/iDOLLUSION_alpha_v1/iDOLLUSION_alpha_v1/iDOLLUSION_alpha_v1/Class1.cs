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
    class Class1
        {
GraphicsDeviceManager graphics;
      static  SpriteBatch spriteBatch;
      public static  Texture2D background, splash, silverButton, goldButton, silverButtonR, goldButtonR, mouseIcon, mainmenu, button, sparkle, characterSelection, characterSelected, characterUnselected, mainMap, collisionMap, producer;
      public  static  SpriteFont gameFont;
      public    Rectangle backgroundRect, silverButtonRect, goldButtonRect, mouseIconRect, mainmenuRect, buttonExitRect, buttonStartRect, character1Rect, character2Rect, producerRect;
        private int screenWidth, screenHeight;
//public variables     
       static  Song techworld;
        static SoundEffect edenEffect;
       static  SoundEffect nocturneEffect;

        public void Main()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
         //   string toProducer = "ToProducer";
        //    XMLReader.readText(toProducer);

        }

         static void  LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            silverButton = Content.Load <Texture2D> ("sprites/silverArrow");
            button = Content.Load<Texture2D>("sprites/button");
            goldButton = Content.Load<Texture2D>("sprites/goldenArrow");
            silverButtonR = Content.Load <Texture2D> ("sprites/silverArrowReversed");
            goldButtonR = Content.Load<Texture2D>("sprites/goldenArrowReversed");
            sparkle = Content.Load<Texture2D>("sprites/goldButton");
            characterSelection = Content.Load<Texture2D>("images/characterSelection");
            characterSelected = Content.Load <Texture2D> ("sprites/characterSelected");
            characterUnselected = Content.Load<Texture2D>("sprites/characterUnselected");
            background = Content.Load<Texture2D>("images/background");
            mainmenu = Content.Load<Texture2D>("images/mainmenu");
            splash = Content.Load<Texture2D>("images/splash");
            gameFont = Content.Load<SpriteFont>("fonts/gameFont");
            mouseIcon = Content.Load<Texture2D>("sprites/mouseIcon");
            edenEffect = Content.Load<SoundEffect>("sounds/eden");
            techworld = Content.Load<Song>("sounds/techworld");
            nocturneEffect = Content.Load<SoundEffect>("sounds/nocturne");
            collisionMap = Content.Load<Texture2D>("images/mainMap/collisionMap");
            mainMap = Content.Load<Texture2D>("images/mainMap/mainMap");
            producer = Content.Load<Texture2D>("images/characters/producer");


            MediaPlayer.Play(techworld);
            MediaPlayer.IsRepeating = true;



        }
        }
    }

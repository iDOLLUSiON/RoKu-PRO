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
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
      public static  Texture2D background, splash, silverButton, goldButton, silverButtonR, goldButtonR, mouseIcon, mainmenu, button, sparkle, characterSelection, characterSelected, characterUnselected, mainMap, collisionMap, producer;
      public    SpriteFont gameFont;
      public    Rectangle backgroundRect, silverButtonRect, goldButtonRect, mouseIconRect, mainmenuRect, buttonExitRect, buttonStartRect, character1Rect, character2Rect, producerRect;
        private int screenWidth, screenHeight;

//These are the values for the colors on the collision map, used for determing what a character is colliding with.
        private const uint chinpo = 4278190335;
        private const uint grass = 4278190080;
        private const uint loli = 4294901760;
        private const uint road = 4280744959;

//determines the direction of the arrows on splash screen. Needs cleaning
         int directionSilver = 1;
         int directionGold = 1;


//Sound Effects and Songs are declared here

         SoundEffect edenEffect, nocturneEffect;
         Song techworld;

//default producer location. Theres a better way to do this
    static  int producerX = 570;
    static  int producerY = 660;
    private Vector2 producerLocation =new Vector2(producerX, producerY);


//Main Menu button location stuff
int buttonSizeDir = 1;
 private Vector2 exitStringCoord = new Vector2(637, 520);
 private Vector2 startStringCoord = new Vector2(637, 380);

//Project versino number, for version control. Just forget about it for now
public double VERSION = .01;  

        
         int splashTimer = 0;
        Random rnd = new Random();


//ENUMS GO HERE
        public enum Location  //Which screen to display.  Every additional location needs an entry
        {
            Splash, //Progression through menu screens is handled via currentLocation++;
            MainMenu,
            CharacterSelection, //This shouldnt be accessible except when chosenIdol = Idols.None
            MainMap,
            Home, //vvv are unimplemented thus far
            Office,
            Studio
        };

        public enum Idols  //Pick a character, any character. These are just placeholder names
        {
            Haruhi,
            Sayaka,
            None
        };
        private Idols chosenIdol = Idols.None;  //this allows us to bring up the character selection screen only once


    Location currentLocation = Location.Splash; //This sets the first screen displayed as the Splash screen

        // object arrays
    //testing


        public Main()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
         //   string toProducer = "ToProducer";
        //    XMLReader.readText(toProducer);

        }
        protected override void Initialize()
        {
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;
            backgroundRect = new Rectangle(0,0,screenWidth,screenHeight);
            mainmenuRect = new Rectangle(0,0,screenWidth,screenHeight);
            silverButtonRect = new Rectangle(230,410,90,49);
            goldButtonRect = new Rectangle(60,0,60,29);
            buttonExitRect = new Rectangle(510, 500, 300, 100);
            buttonStartRect = new Rectangle(510, 360, 300, 100);
            character1Rect = new Rectangle(200, 300, 300, 200);
            character2Rect = new Rectangle(800, 300, 300, 200);
            producerRect = new Rectangle(producerX, producerY, 50, 50);

            base.Initialize();
        }
        protected override void LoadContent()
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
        protected override void UnloadContent()
        {
        }

//GAME UPDATE LOOP HERE
        protected override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
            if (currentLocation == Location.MainMap)
            {
                //movement controls for main map go here
                if (ks != null)
                {
                    int movementSpeed = 7;
                    if(ks.IsKeyDown(Keys.W))
                    {
                        producerY-=movementSpeed;
                    }
                    if(ks.IsKeyDown(Keys.S))
                    {
                        producerY+=movementSpeed;
                    }
                    if(ks.IsKeyDown(Keys.A))
                    {
                        producerX-=movementSpeed;
                    }
                    if(ks.IsKeyDown(Keys.D))
                    {
                        producerX+=movementSpeed;
                    }
                }

// collision handling           
                uint currentArea = road; //This can technically be set to anything since it will be overwritten in just a few lines.
uint[] myUint = new uint[1];
            if (producerX >= 0 && producerX < collisionMap.Width && producerY >= 0 && producerY < collisionMap.Height)
            {
                collisionMap.GetData(0, new Rectangle(producerX, producerY, 1, 1), myUint, 0, 1);
                currentArea = myUint[0];
            }


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





            }

            
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) Exit();
            if (currentLocation == Location.Splash && (Mouse.GetState().LeftButton == ButtonState.Pressed))
            {
                currentLocation++;   //Clicking on teh splash proceeds tothe next screen

if (!edenEffect.IsDisposed) //check if already unloaded, if not play, otherwise, reload
                {
                                    edenEffect.Play();
                }
else
{
    //add code that reloads edenEffect
}
            }
            mouseIconRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, mouseIcon.Width, mouseIcon.Height); //Mouse icon
            base.Update(gameTime);
        }


//DRAW LOOP HERE
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
       var mouseState = Mouse.GetState();              // use mouseState instead of Mouse.GetState() from here on out


        Point mousePosition = new Point(mouseState.X, mouseState.Y);
            spriteBatch.Begin();
            if (currentLocation == Location.Splash) //SPLASH DRAW LOOP
            {
                spriteBatch.Draw(splash, backgroundRect, Color.White);
                silverButtonRect.X += 5*directionSilver;
                goldButtonRect.X += 6*directionGold;
               
 //handle collisions between arrows and walls
                if (silverButtonRect.X == 220 || silverButtonRect.X == 510)
                {
                    directionSilver *= -1;
                }
                if (goldButtonRect.X < 0 || goldButtonRect.X + goldButtonR.Width > 1280)
                {
                    directionGold *= -1;
                }

                spriteBatch.DrawString(gameFont, "Ver: " + VERSION, new Vector2(0, 690), Color.White);  //Draw game version number
             
   splashTimer++;     //Automatically proceed to main menu after a time
                if (splashTimer > 2000)
                {
                    currentLocation++;
                    splashTimer = 0;
                    edenEffect.Play();
                }
//Flip arrow sprite as neccessary
                if (directionSilver > 0)
                {
                    spriteBatch.Draw(silverButton, silverButtonRect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(silverButtonR, silverButtonRect, Color.White);
                }
                if (directionGold > 0)
                {
                    spriteBatch.Draw(goldButton, goldButtonRect, Color.White);
                }
                if (directionGold < 0)
                {
                    spriteBatch.Draw(goldButtonR, goldButtonRect, Color.White);
                }
            }
////////////////////////////////////////////////////////////////////////////////////
/// 
/// 
            else if (currentLocation == Location.MainMenu) //MAIN MENU DRAW LOOP
            {
                MediaPlayer.Stop();
                techworld.Dispose();

                spriteBatch.Draw(mainmenu, backgroundRect, Color.White);
                spriteBatch.Draw(button, buttonExitRect, Color.White);
                spriteBatch.Draw(button, buttonStartRect, Color.White);
                spriteBatch.DrawString(gameFont, "Exit", exitStringCoord, Color.Brown);
                    //TODO change font size, move dynamically
                spriteBatch.DrawString(gameFont, "Start", startStringCoord, Color.DarkGoldenrod);
                    //TODO change font size, move dynamically

                /////// make buttons grow and shrink                   
                if (buttonSizeDir == 1) //Whether the button is shrinking or growing
                {
                    exitStringCoord.X += 2;
                    buttonExitRect.Width += 2;
                    buttonExitRect.X += 1;
                    startStringCoord.X -= 2;
                    buttonStartRect.X -= 1;
                    buttonStartRect.Width -= 2;
                    if (buttonExitRect.Width > 310)
                    {
                        buttonSizeDir = 0;
                    }
                }
                if (buttonSizeDir == 0)
                {
                    exitStringCoord.X -= 2;
                    buttonExitRect.Width -= 2;
                    buttonExitRect.X -= 1;
                    startStringCoord.X += 2;
                    buttonStartRect.X += 1;
                    buttonStartRect.Width += 2;
                    if (buttonExitRect.Width < 290)
                    {
                        buttonSizeDir = 1;
                    }
                } // End of button resizing


                if (buttonExitRect.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    //add buffer for previous clicks so that a single click doesnt trigger this from the previous screen
                {
                    Exit();
                }
                if (buttonStartRect.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    //add buffer for previous clicks so that a single click doesnt trigger this from the previous screen
                {
                    if (chosenIdol == Idols.None)
                    {
                        currentLocation++;
                    }
                    else
                    {
                        currentLocation += 2;
                    }

                }

            }
/////////////////////////////////////////////////////////////////////////
 
            if (currentLocation == Location.CharacterSelection)  //CHARACTER SELECTION DRAW LOOP
            {
              spriteBatch.Draw(characterSelection, backgroundRect, Color.White);// Draw appropriate background

                           // This makes the portrait you hover over glow
                if (character1Rect.Contains(mousePosition))      
                {
                    spriteBatch.Draw(characterSelected, character1Rect, Color.White);
                }
                else
                {
                  spriteBatch.Draw(characterUnselected, character1Rect, Color.White);

                }
                if (character2Rect.Contains(mousePosition))
                {
                    spriteBatch.Draw(characterSelected, character2Rect, Color.White);
                }
                else
                {
                  spriteBatch.Draw(characterUnselected, character2Rect, Color.White);

                }

//Determine which button has been selected
                if (character2Rect.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)  //add buffer for previous clicks so that a single click doesnt trigger this from the previous screen
                {
                    chosenIdol = Idols.Haruhi;
                    currentLocation++;
                }
                if (character1Rect.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)  //add buffer for previous clicks so that a single click doesnt trigger this from the previous screen
                {
                    chosenIdol = Idols.Sayaka;
                    currentLocation++;
                }


            }
/////////////////////////////////////////////////////////////////////////


            else if (currentLocation == Location.MainMap) //MAIN MAP DRAW LOOP
                {
                    
                //draw main navigational map and invisible collision map.  Remember to go in order [back to front}
                spriteBatch.Draw(collisionMap, new Rectangle(0,0,screenWidth,screenHeight), Color.White);
                spriteBatch.Draw(mainMap, backgroundRect, Color.White);
                spriteBatch.Draw(producer,  new Rectangle(producerX, producerY , 40, 40), Color.White);
                edenEffect.Dispose();
                }
////////////////////////////////////////////////////////////////////////
 
//ALWAYS DRAW LOOP
            spriteBatch.Draw(mouseIcon, mouseIconRect, Color.White);
            spriteBatch.DrawString(gameFont, Mouse.GetState().X.ToString() + " " + Mouse.GetState().Y.ToString(), new Vector2(0, 100), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

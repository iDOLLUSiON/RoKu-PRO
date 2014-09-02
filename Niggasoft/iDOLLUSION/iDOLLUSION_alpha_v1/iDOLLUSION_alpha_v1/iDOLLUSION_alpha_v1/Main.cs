using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using iDOLLUSION_alpha_v1.characters;
using iDOLLUSION_alpha_v1.scenes;
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
        public SpriteFont gameFont, gameFontLarge;
        public Rectangle backgroundRect,  mouseIconRect, mainmenuRect, buttonExitRect, buttonStartRect, character1Rect, character2Rect, producerRect;
        private int screenWidth, screenHeight;
        private ImageLoader imageLoader;

//determines the direction of the arrows on splash screen. Needs cleaning. Move to seperate class?
         int directionSilver = 1;
         int directionGold = 1;

//Sound Effects and Songs are declared here
        public static SoundEffect edenEffect;
        public  static Song techworld;

//default producer location. Theres a better way to do this
        static  int producerX = 570;
        static  int producerY = 660;


//Main Menu button location stuff
        int buttonSizeDir = 1;
        private Vector2 exitStringCoord = new Vector2(637, 520);
        private Vector2 startStringCoord = new Vector2(637, 380);

//Project versino number, for version control. Just forget about it for now
        public double VERSION = .01;  



//ENUMS GO HERE
        public  enum Scene  //Which screen to display.  Every additional location needs an entry
        {
            Splash, //Progression through menu screens is handled via currentScene++;
            MainMenu,
            CharacterSelection, //This shouldnt be accessible except when chosenIdol = Idols.None
            MainMap,
            Home, //vvv are unimplemented thus far
            Office,
            Studio,
            Schedule,
            Inbox,
            TESTZONE
        };

    public static Scene currentScene = Scene.Splash; //This sets the first screen displayed as the Splash screen
    public static Scene lastScene;


        public enum Idols  //Pick a character, any character. These are just placeholder names
        {
            Haruhi,
            Sayaka,
            None
        };
        private Idols chosenIdol = Idols.None;  //this allows us to bring up the character selection screen only once



        // object arrays
    //testing

//PUBLIC METHODS
        public static int getProducer(string c)
        {
        switch (c)
            {
            case ("X"):
                    {
                    return producerX;
                    }
default:
                {
                    return producerY;
                }
            }
        }


        public static void setProducerLocation(int x, int y)
        {
            producerX = x;
            producerY = y;
        }



       public  void setGameScreen(Scene scene)
       {
            if (currentScene != scene)
            {
                if (scene == Scene.CharacterSelection && chosenIdol != Idols.None)
                {
                    return;
                }
                if (scene == Scene.Office )
                {
                    producerX = 860;
                    producerY = 676;
                    return;
                }
                else
                {
                    currentScene = scene;
                 //   Collision.resetProducerLocation();
                }
            }
            return;
        }

        public Scene getCurrentScreen()
        {
            return (currentScene);
        }

        public void setRectX(Rectangle rect, int x)
        {
            rect.X = x;
            return;
        }

        public void setRectX(Rectangle rect, int x, int y)
        {
            rect.X = x;
            rect.Y = y;
            return;
        }



/////////////////////////////////////////////
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
            buttonExitRect = new Rectangle(510, 500, 300, 100);
            buttonStartRect = new Rectangle(510, 360, 300, 100);
            character1Rect = new Rectangle(200, 300, 300, 200);
            character2Rect = new Rectangle(800, 300, 300, 200);
            producerRect = new Rectangle(producerX, producerY, 50, 50);
            imageLoader = new ImageLoader(Content);

            base.Initialize();
        }
        protected override void LoadContent()
        {


            spriteBatch = new SpriteBatch(GraphicsDevice);
//Textures
            gameFont = Content.Load<SpriteFont>("fonts/gameFont");
            gameFontLarge = Content.Load<SpriteFont>("fonts/gameFontLarge");
//Sounds
            edenEffect = Content.Load<SoundEffect>("sounds/eden");
            techworld = Content.Load<Song>("sounds/techworld");

        



        }
        protected override void UnloadContent()
        {
        }

//GAME UPDATE LOOP HERE
        protected override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            MouseState ms = Mouse.GetState();
       var mouseState = Mouse.GetState();              // use mouseState instead of Mouse.GetState() from here on out
        Point mousePosition = new Point(mouseState.X, mouseState.Y);

            string sColorval = "";
            uint[] myUint = new uint[1];
if (ms.X >= 0 && ms.X < 1280 && ms.Y >= 0 && ms.Y < 720)  // DISPLAYS color value of collision map
            {
                ImageLoader.testZone.GetData(0, new Rectangle(ms.X, ms.Y, 1, 1), myUint, 0, 1);
                sColorval = myUint[0].ToString();
            }
            Window.Title = ms.X.ToString() + "," + ms.Y.ToString() + " - " + sColorval;


            if (currentScene == Scene.MainMap || currentScene == Scene.Office)
            {
                if (ks.IsKeyDown(Keys.P))
                {
                if (currentScene == Scene.MainMap)
                    {
                    lastScene = Scene.MainMap;
                    }
                else
                    {
                    lastScene = Scene.Office;
                    }
                   setGameScreen(Scene.Schedule);
                   // Collision.setScene(Scene.Office);
                    new Events(phaseClock.Day.Monday, phaseClock.Time.Morning, Events.EventType.AUDITION);  //TESTING REMOVE LATER REMOVE LATER
                    new Events(phaseClock.Day.Tuesday, phaseClock.Time.Noon, Events.EventType.AUDITION);  //TESTING REMOVE LATER REMOVE LATER
                    new Events(phaseClock.Day.Wednesday, phaseClock.Time.Afternoon, Events.EventType.AUDITION);  //TESTING REMOVE LATER REMOVE LATER
                    new Events(phaseClock.Day.Thursday, phaseClock.Time.Evening, Events.EventType.AUDITION);  //TESTING REMOVE LATER REMOVE LATER
                }
                //movement controls for main map go here
                if (ks != null)
                {
                    int movementSpeed = 7;
                    Vector2 producerShift = new Vector2(0,0);
                    if(ks.IsKeyDown(Keys.W))
                    {
                        producerShift.Y-=movementSpeed;
                    }
                    if(ks.IsKeyDown(Keys.S))
                    {
                        producerShift.Y+=movementSpeed;
                    }
                    if(ks.IsKeyDown(Keys.A))
                    {
                        producerShift.X-=movementSpeed;
                    }
                    if(ks.IsKeyDown(Keys.D))
                    {
                        producerShift.X+=movementSpeed;
                    }

                    Collision.processMovement(producerShift);
                }
            }

            if (currentScene == Scene.Office)
            {
                if (MouseDetection.clicked())
                {
                   Collision.processMovement(new Vector2(mouseState.X, mouseState.Y));
                }
            }
            if (currentScene == Scene.Schedule)
            {
                if (MouseDetection.clicked())
                {
                   Collision.setScene(lastScene);
                }
            }


 if (Keyboard.GetState().IsKeyDown(Keys.Space)) Exit();
 if(ks.IsKeyDown(Keys.O))         // TESTING REMOVE LATER
                    {
                        phaseClock.spendDay();
                    }
  if (currentScene == Scene.Splash)
  {
      Splash.upDate();

  }
  mouseIconRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, ImageLoader.mouseIcon.Width, ImageLoader.mouseIcon.Height); //Mouse icon
           MouseDetection. checkTimeout();
            phaseClock.upDate();
            base.Update(gameTime);
        }







//DRAW LOOP HERE
        protected override void Draw(GameTime gameTime)
        {
       GraphicsDevice.Clear(Color.CornflowerBlue);
       var mouseState = Mouse.GetState();              // use mouseState instead of Mouse.GetState() from here on out
        Point mousePosition = new Point(mouseState.X, mouseState.Y);
            spriteBatch.Begin();
            if (currentScene == Scene.Splash) //SPLASH DRAW LOOP
            {
                spriteBatch.Draw(ImageLoader.splash, backgroundRect, Color.White);
                spriteBatch.DrawString(gameFont, "Ver: " + VERSION, new Vector2(0, 690), Color.White);  //Draw game version number
            }
////////////////////////////////////////////////////////////////////////////////////
/// 
/// 
            else if (currentScene == Scene.MainMenu) //MAIN MENU DRAW LOOP
            {
                MediaPlayer.Stop();
                techworld.Dispose();
                spriteBatch.Draw(ImageLoader.mainmenu, backgroundRect, Color.White);
                spriteBatch.Draw(ImageLoader.button, buttonExitRect, Color.White);
                spriteBatch.Draw(ImageLoader.button, buttonStartRect, Color.White);
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


                if (buttonExitRect.Contains(mousePosition) && MouseDetection.clicked())
                    //add buffer for previous clicks so that a single click doesnt trigger this from the previous screen
                {
                    Exit();
                }
                if (buttonStartRect.Contains(mousePosition) && MouseDetection.clicked())
                    //add buffer for previous clicks so that a single click doesnt trigger this from the previous screen
                {
                    if (chosenIdol == Idols.None)
                    {
                        currentScene++;
                    }
                    else
                    {
                        currentScene += 2;
                    }

                }

            }
/////////////////////////////////////////////////////////////////////////
 
            if (currentScene == Scene.CharacterSelection)  //CHARACTER SELECTION DRAW LOOP
            {
                spriteBatch.Draw(ImageLoader.characterSelection, backgroundRect, Color.White);// Draw appropriate background

                           // This makes the portrait you hover over glow
                if (character1Rect.Contains(mousePosition))      
                {
                    spriteBatch.Draw(ImageLoader.characterSelected, character1Rect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(ImageLoader.characterUnselected, character1Rect, Color.White);

                }
                if (character2Rect.Contains(mousePosition))
                {
                    spriteBatch.Draw(ImageLoader.characterSelected, character2Rect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(ImageLoader.characterUnselected, character2Rect, Color.White);

                }

//Determine which button has been selected
                if (character2Rect.Contains(mousePosition) && MouseDetection.clicked())  //add buffer for previous clicks so that a single click doesnt trigger this from the previous screen
                {
                    chosenIdol = Idols.Haruhi;
                    currentScene++;
                }
                if (character1Rect.Contains(mousePosition) && MouseDetection.clicked())  //add buffer for previous clicks so that a single click doesnt trigger this from the previous screen
                {
                    chosenIdol = Idols.Sayaka;
                    currentScene++;
                }


            }
/////////////////////////////////////////////////////////////////////////


            else if (currentScene == Scene.MainMap) //MAIN MAP DRAW LOOP
                {
                    
                //draw main navigational map and invisible collision map.  Remember to go in order [back to front}
                    spriteBatch.Draw(ImageLoader.collisionMap, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    spriteBatch.Draw(ImageLoader.mainMap, backgroundRect, Color.White);
                    spriteBatch.Draw(ImageLoader.producer, new Rectangle(producerX, producerY, 40, 40), Color.White);
                edenEffect.Dispose();
                }

            else if (currentScene == Scene.Schedule) //Schedule draw loop
                {
                    spriteBatch.Draw(ImageLoader.schedule, backgroundRect, Color.White);
                    spriteBatch.Draw(ImageLoader.selectionMarker, new Rectangle(phaseClock.getSelectionCoord() - 40, phaseClock.yCoord - 50, 209, 170), Color.White);

                 foreach (Events events in Events.eventList)                 //Draw each event onto the schedule
                    {
                        spriteBatch.DrawString(gameFont, events.getEventText(), events.eCoords, Color.Black);
                    }
                spriteBatch.DrawString(gameFontLarge, phaseClock.getWeek(), new Vector2(1220,179), Color.Black);
        
                }
            else if (currentScene == Scene.Office) //Office DRAW LOOP
                {
                 spriteBatch.Draw(ImageLoader.officeCollisionMap, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    spriteBatch.Draw(ImageLoader.office, backgroundRect, Color.White);
                    spriteBatch.Draw(ImageLoader.producer, new Rectangle(producerX, producerY, 40, 40), Color.White);
                edenEffect.Dispose();
                }
            else if (currentScene == Scene.TESTZONE) //Office DRAW LOOP
                {
                 spriteBatch.Draw(ImageLoader.testZoneCollision, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    spriteBatch.Draw(ImageLoader.testZone, backgroundRect, Color.White);
                }

 
//ALWAYS DRAW LOOP
            spriteBatch.Draw(ImageLoader.mouseIcon, mouseIconRect, Color.White);
            spriteBatch.DrawString(gameFont, Mouse.GetState().X.ToString() + " " + Mouse.GetState().Y.ToString(), new Vector2(0, 100), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

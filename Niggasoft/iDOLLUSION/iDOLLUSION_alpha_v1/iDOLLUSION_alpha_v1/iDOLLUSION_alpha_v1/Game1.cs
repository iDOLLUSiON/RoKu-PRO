using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D background, splash, silverButton, goldButton, silverButtonR, goldButtonR, mouseIcon, mainmenu;
        private SpriteFont gameFont;
        private Rectangle backgroundRect, silverButtonRect, goldButtonRect, mouseIconRect, mainmenuRect;
        private int screenWidth, screenHeight;
        bool atSplash = true;
        bool atMainMenu = false;
         int directionSilver = 1;
         int directionGold = 1;
         Song mySong;


        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            silverButton = Content.Load <Texture2D> ("sprites/silverArrow");
            goldButton = Content.Load<Texture2D>("sprites/goldenArrow");
            silverButtonR = Content.Load <Texture2D> ("sprites/silverArrowReversed");
            goldButtonR = Content.Load<Texture2D>("sprites/goldenArrowReversed");
            background = Content.Load<Texture2D>("images/background");
            mainmenu = Content.Load<Texture2D>("images/mainmenu");
            splash = Content.Load<Texture2D>("images/splash");
            gameFont = Content.Load<SpriteFont>("fonts/gameFont");
            mouseIcon = Content.Load<Texture2D>("sprites/mouseIcon");
            mySong = Content.Load<Song>("sounds/kommSusserTod");
            MediaPlayer.Play(mySong);
            MediaPlayer.IsRepeating = true;



        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) Exit();
            if (atSplash && (Mouse.GetState().LeftButton == ButtonState.Pressed))
            {
                atSplash = false;
                atMainMenu = true;
            }
            mouseIconRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, mouseIcon.Width, mouseIcon.Height);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();
            if (atSplash)
            {
                spriteBatch.Draw(splash, backgroundRect, Color.White);
                silverButtonRect.X +=5*directionSilver;
                goldButtonRect.X +=6*directionGold;
                    //handle collisions with walls
                if (silverButtonRect.X == 220 || silverButtonRect.X == 510)
                {
                    directionSilver *= -1;
                }
                if (goldButtonRect.X < 0 || goldButtonRect.X + goldButtonR.Width > 1280)
                {
                    directionGold *= -1;
                }
            }
            if (atSplash)
            {
    
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
            else if (atMainMenu)
            {     
                    spriteBatch.Draw(mainmenu, backgroundRect, Color.White);
                
            }
            else
            {
                spriteBatch.Draw(background, backgroundRect, Color.White);
            }
            if (atMainMenu)
            {
            }
            spriteBatch.Draw(mouseIcon, mouseIconRect, Color.White);
            spriteBatch.DrawString(gameFont, "Sample text", new Vector2(0, 40), Color.White);
            spriteBatch.DrawString(gameFont, Mouse.GetState().X.ToString() + " " + Mouse.GetState().Y.ToString(), new Vector2(0, 100), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

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
        private Texture2D background, splash, silverButton, goldButton, silverButtonR, goldButtonR, mouseIcon;
        private SpriteFont gameFont;
        private Rectangle backgroundRect, silverButtonRect, goldButtonRect, mouseIconRect;
        private int screenWidth, screenHeight;
        bool atSplash = true;
         int modifier1 = 1;
         int modifier2 = 1;         


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
            silverButtonRect = new Rectangle(0,0,60,29);
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
            splash = Content.Load<Texture2D>("images/splash");
            gameFont = Content.Load<SpriteFont>("fonts/gameFont");
            mouseIcon = Content.Load<Texture2D>("sprites/mouseIcon");
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
                silverButtonRect.X +=5*modifier1;
                goldButtonRect.X +=6*modifier2;
                    //handle collisions with walls
                if (silverButtonRect.X == 1280 || silverButtonRect.X == 0)
                {
                    modifier1 *= -1;
                }
                if (goldButtonRect.X == 1280 || goldButtonRect.X == 0)
                {
                    modifier2 *= -1;
                }
            }
            if (!atSplash)
            {
                spriteBatch.Draw(background, backgroundRect, Color.White);
            }
            if (modifier1 > 0)
            {
                spriteBatch.Draw(silverButton, silverButtonRect, Color.White);
            }
            else
            {
                spriteBatch.Draw(silverButtonR, silverButtonRect, Color.White);
            }
            if (modifier2 > 0)
            {
                spriteBatch.Draw(goldButton, goldButtonRect, Color.White);
            }
            else
            {
                spriteBatch.Draw(goldButtonR, goldButtonRect, Color.White);
            }

            spriteBatch.Draw(goldButton, goldButtonRect, Color.White);
            spriteBatch.Draw(mouseIcon, mouseIconRect, Color.White);
            spriteBatch.DrawString(gameFont, "Sample text", new Vector2(0, 40), Color.White);
            spriteBatch.DrawString(gameFont, Mouse.GetState().X.ToString() + " " + Mouse.GetState().Y.ToString(), new Vector2(0, 100), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

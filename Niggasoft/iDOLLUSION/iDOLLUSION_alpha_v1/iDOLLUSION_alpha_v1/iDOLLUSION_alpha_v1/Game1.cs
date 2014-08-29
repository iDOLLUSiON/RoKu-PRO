using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace iDOLLUSION_alpha_v1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D silverButton, goldButton;
        private SpriteFont gameFont;
        private Rectangle silverButtonRect, goldButtonRect;

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
            silverButtonRect = new Rectangle(0,0,64,64);
            goldButtonRect = new Rectangle(50,0,64,64);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            silverButton = Content.Load <Texture2D> ("sprites/silverButton");
            goldButton = Content.Load<Texture2D>("sprites/goldButton");
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) Exit();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(silverButton, silverButtonRect,Color.White );
            spriteBatch.Draw(goldButton, goldButtonRect, Color.White); 
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

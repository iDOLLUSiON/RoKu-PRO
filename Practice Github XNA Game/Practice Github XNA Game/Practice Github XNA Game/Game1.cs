using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Practice_Github_XNA_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D mouseIcon, bomb, shuriken, explosion;//2d images
        SpriteFont gameFont;//font
        Rectangle mouseIconRect, bombRect, shurikenRect;//rectangles for basic collision and shit
        int screenWidth, screenHeight;
        bool boom;
        protected int bombTimer = 0;
        protected int bombLimit = 50;
        protected bool bombExploded = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            screenWidth = GraphicsDevice.Viewport.Width;//game screen width
            screenHeight = GraphicsDevice.Viewport.Height;// game screen height
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads images into game
            mouseIcon = Content.Load<Texture2D>("sprites/mouseIcon");
            bomb = Content.Load<Texture2D>("sprites/bomb");
            shuriken = Content.Load<Texture2D>("sprites/shuriken");
            explosion = Content.Load<Texture2D>("sprites/explosion");
            //loads font into game
            gameFont = Content.Load<SpriteFont>("fonts/gameFont");
            //adds collision for bomb and shuriken images
            bombRect = new Rectangle(100, 100, bomb.Width, bomb.Height);
            shurikenRect = new Rectangle(100, 200, shuriken.Width, shuriken.Height);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        protected override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);


            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) this.Exit();//exits game when space key is pressed
            //im sure theres a more efficient way of doing this i just dont know how atm
            //keyboard controls for the shuriken
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) shurikenRect.X += 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) shurikenRect.X -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) shurikenRect.Y -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) shurikenRect.Y += 5;
            //keyboard controls for the bomb
            if (Keyboard.GetState().IsKeyDown(Keys.D)) bombRect.X += 5;
            if (Keyboard.GetState().IsKeyDown(Keys.A)) bombRect.X -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.W)) bombRect.Y -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.S)) bombRect.Y += 5;
            //screen bounds collision for shuriken
            if (shurikenRect.X < 0) shurikenRect.X = 0;
            if (shurikenRect.Y < 0) shurikenRect.Y = 0;
            if (shurikenRect.X + shuriken.Width > screenWidth) shurikenRect.X = screenWidth - shuriken.Width;
            if (shurikenRect.Y + shuriken.Height > screenHeight) shurikenRect.Y = screenHeight - shuriken.Height;
            //screen bounds collision for bomb
            if (bombRect.X < 0) bombRect.X = 0;
            if (bombRect.Y < 0) bombRect.Y = 0;
            if (bombRect.X + bomb.Width > screenWidth) bombRect.X = screenWidth - bomb.Width;
            if (bombRect.Y + bomb.Height > screenHeight) bombRect.Y = screenHeight - bomb.Height;
            
            if (bombExploded)
            {
                boom = true;
                bombTimer++;
                if (bombTimer > bombLimit)
                {
                    bombExploded = false;bombTimer = 0;
                }
            }
            else
            {
                boom = false;
            }
            if(bombRect.Contains(mousePosition))
            {
                if(mouseState.LeftButton == ButtonState.Pressed)
                {
                    bombExploded = true;
                    bombTimer = 0;
                }
            }
            if(bombRect.Intersects(shurikenRect))
            {
                bombExploded=true;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            mouseIconRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, mouseIcon.Width, mouseIcon.Height);

            spriteBatch.Begin();
            spriteBatch.Draw(mouseIcon, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
            if (boom)//is true when intersects
            {
                spriteBatch.Draw(explosion, new Vector2(bombRect.X - (bomb.Width / 2), bombRect.Y - (bomb.Height / 2)), Color.White);//draw explosion
            }
            else
            {
                spriteBatch.Draw(bomb, bombRect, Color.White);//else draw bomb
            }
            spriteBatch.Draw(shuriken, shurikenRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

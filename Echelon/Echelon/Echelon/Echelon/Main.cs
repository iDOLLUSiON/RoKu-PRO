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

namespace Echelon
{

    public class Main : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private SpriteControl spriteControl;
        private int direction;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);//must instantiate SpriteBatch first
            spriteControl = new SpriteControl(this.Content,this.spriteBatch);//pass through Main's content manager and SpriteBatch

            SetGameScreenProperties(false,1920,1080); //use for fast load, sloppier look
            //SetGameScreenProperties(true,0,0); //use for fullscreen, cleaner look
            base.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            //section for misc functions
            if(Keyboard.GetState().IsKeyDown(Keys.Space))Exit();//exits game is space key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.F)) SetGameScreenProperties(true, 0, 0);//sets full screen if the key F is pressed
            
            //section for checks of the controls
            if (Keyboard.GetState().IsKeyDown(Keys.A)) direction = 0;//left
            else if (Keyboard.GetState().IsKeyDown(Keys.D)) direction = 1; //right
            else direction = 4;//neutral
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            spriteBatch.Begin();
            switch (direction)
            {
                case 0://left
                    spriteControl.moveSprites(direction);
                    break;
                case 1://right
                    spriteControl.moveSprites(direction);
                    break;
                case 4://neutral
                    spriteControl.moveSprites(direction);
                    break;
                default:
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /////////////////////////////////////custom methods/////////////////////////////////////////////////
        //seperate method for changing the properties of the game screen
        public void SetGameScreenProperties(bool isFullScreen, int screenWidth, int screenHeight)
        {
            if (isFullScreen)
            {
                graphics.IsFullScreen = true;
            }
            else
            {
                graphics.PreferredBackBufferWidth = screenWidth;
                graphics.PreferredBackBufferHeight = screenHeight;
            }
            graphics.ApplyChanges();
        }
    }
}

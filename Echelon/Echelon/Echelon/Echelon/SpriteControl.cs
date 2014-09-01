using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Echelon
{
    class SpriteControl
    {
        private SpriteBatch thisSpriteBatch;
        private Texture2D neutral, left, right;
        private Rectangle playerRectangle, playerRectangleN;
        private Color color = Color.White;

        public SpriteControl(ContentManager content, SpriteBatch spriteBatch)//pass the Main ContentManager and SpriteBatch through the constructor for the class to use, all loading is done here
        {
            //load content manager and spritebatch from main here
            thisSpriteBatch = spriteBatch;//instantiates a seperate SpriteBatch for the class to use
            content.RootDirectory = "Content";//sets directory to Content, do not need to instantiate a seperate content manager for seperate classes

            //load rectangles
            playerRectangle = new Rectangle(0, 0, 28, 35);
            playerRectangleN = new Rectangle(playerRectangle.X,0,24,40);

            //load sprites in this section
            neutral = content.Load<Texture2D>("sprites/samus_movement/neutral");//neutral face when player isnt moving
            left = content.Load<Texture2D>("sprites/samus_movement/l/l0");//left face when player is moving left
            right = content.Load<Texture2D>("sprites/samus_movement/r/r0");//right face when player is moving right

            //load images/non-sprites here
        }

        public void moveSprites(int direction)//controls
        {
            switch (direction)
            {
                case 0://left
                    playerRectangle.X -= 10; //10 left pixels movement a tick
                    playerRectangle.Y = Mouse.GetState().Y; //sets Y coord equal to mouse Y coord
                    thisSpriteBatch.Draw(left, playerRectangle, color);//draws left face
                    break;
                case 1://right
                    playerRectangle.X += 10;//10 right pixels movement a tick
                    playerRectangle.Y = Mouse.GetState().Y;
                    thisSpriteBatch.Draw(right, playerRectangle, color);//draws right face
                    break;
                    //case 2 and case 3 will be up and down respectively
                case 4://neutral
                    thisSpriteBatch.Draw(neutral,new Vector2(playerRectangle.X,Mouse.GetState().Y),playerRectangleN,color);//draws neutral face
                    break;
                default:
                    break;
            }
        }
    }
}

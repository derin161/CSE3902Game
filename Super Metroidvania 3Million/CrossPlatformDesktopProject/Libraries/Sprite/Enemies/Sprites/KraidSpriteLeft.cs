using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class KraidSpriteLeft : ISprite
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int counter;
        private Kraid Kraid;

        public KraidSpriteLeft(Texture2D texture, Kraid k)
        {
            Texture = texture;
            Rows = 2;
            Columns = 2;
            currentFrame = 0;
            counter = 0;
            Kraid = k;

        }

        public void Update(GameTime gameTime)
        {

            //change the frame after 10 counts
            if (counter == 4)
            {
                counter = 0;
                currentFrame++;
                if (currentFrame == 2)
                    currentFrame = 0;
            }
            counter++;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            spriteBatch.Draw(Texture, Kraid.Space, sourceRectangle, Color.White);
        }

        public Boolean IsDead()
        {
            return false;
        }

        //Will need to create a new factory for game objects.


    }
}
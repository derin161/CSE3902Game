using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class GeegaSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private Geega geega;
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private int counter;

        public GeegaSprite(Texture2D texture, Geega g)
        {
            Texture = texture;
            Rows = 2;
            Columns = 2;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            counter = 0;
            geega = g;

        }

        public void Update(GameTime gameTime)
        {
            //change the frame after 10 counts if not frozen
            if (!geega.frozen)
            {
                if (counter == 3)
                {
                    counter = 0;
                    currentFrame++;
                    if (currentFrame == 2)
                        currentFrame = 0;
                }
                counter++;
            }
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the sprite
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            if (geega.damaged)
            {
                spriteBatch.Draw(Texture, geega.Space, sourceRectangle, Color.Transparent);
                geega.damaged = false;
            }
            if (geega.frozen)
            {
                spriteBatch.Draw(Texture, geega.Space, sourceRectangle, Color.DodgerBlue);
            }
            else
            {
                spriteBatch.Draw(Texture, geega.Space, sourceRectangle, Color.White);
            }
        }
        public Boolean IsDead()
        {
            return false;
        }
    }
}

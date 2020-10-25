using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class MemuSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private int counter;
        private Memu memu;

        public MemuSprite(Texture2D texture, Memu m)
        {
            Texture = texture;
            Rows = 1;
            Columns = 2;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            memu = m;
        }

        public void Update(GameTime gameTime)
        {
            //change the frame after 10 counts
            if (counter == 10)
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

            spriteBatch.Draw(Texture, memu.Space, sourceRectangle, Color.White);
        }
        public Boolean IsDead()
        {
            return false;
        }

    }
}

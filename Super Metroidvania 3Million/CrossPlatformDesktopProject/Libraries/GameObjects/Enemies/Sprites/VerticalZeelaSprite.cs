using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class VerticalZeelaSprite : ISprite
    {
        //Author: Will Floyd
        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private int count;
        private VerticalZeela verticalZeela;

        public VerticalZeelaSprite(Texture2D texture, VerticalZeela vz)
        {
            Texture = texture;
            Rows = 2;
            Columns = 4;
            currentFrame = 2;
            totalFrames = Rows * Columns;
            count = 0;
            verticalZeela = vz;

        }

        public void Update(GameTime gameTime)
        {
            //change the frame after 10 counts
            if (count == 10)
            {
                count = 0;
                currentFrame++;
                if (currentFrame == 4)
                {
                    currentFrame = 2;
                }
            }
            count++;

            
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            spriteBatch.Draw(Texture, verticalZeela.Space, sourceRectangle, Color.White);
        }

        public Boolean IsDead()
        {
            return false;
        }
        
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class ZeelaSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private float x, y, initialX;
        private int count;
        private int direction;

        public ZeelaSprite(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Rows = 2;
            Columns = 4;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            x = location.X;
            initialX = location.X;
            y = location.Y;
            count = 0;
            direction = 1;
        }

        public void Update(GameTime gameTime)
        {
            //Move to the next frame after 10 counts
            if (count == 10)
            {
                count = 0;
                currentFrame++;
                if (currentFrame == 2)
                {
                    currentFrame = 0;
                }
            }
            count++;

            //Move horizontally back and forth across the screen
            x += direction;
            if (Math.Abs(x - initialX) > 100)
            {
                direction *= -1;
            }
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)x, (int)y, width*2, height*2);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public Boolean IsDead()
        {
            return false;
        }
        
    }
}

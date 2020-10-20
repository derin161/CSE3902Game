using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Memu : IEnemy
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private float x, y, initialX;
        private int counter;
        private int direction;

        public Memu(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Rows = 1;
            Columns = 2;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            x = location.X;
            initialX = location.X;
            y = location.Y;
            direction = 1;
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

            //move back and forth in x direction
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

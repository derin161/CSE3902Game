using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class ReverseSideHopperSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private float x, y, initialY;
        private int count;
        private int direction;
        private ReverseSideHopper reverseSideHopper;
        public ReverseSideHopperSprite(Texture2D texture, ReverseSideHopper rsh)
        {
            Texture = texture;
            Rows = 2;
            Columns = 6;
            currentFrame = 3;
            totalFrames = Rows * Columns;
            reverseSideHopper = rsh;
            direction = 1;
        }

        public void Update(GameTime gameTime)
        {
            //change the frame after 20 counts
            if (count == 20)
            {
                count = 0;
                direction *= -1;
                currentFrame++;
                if (currentFrame == 6)
                {
                    currentFrame = 3;
                }
            }

            //Jump while on frame 5
            if (currentFrame == 5)
            {
                reverseSideHopper.Jump(count, direction);
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

            spriteBatch.Draw(Texture, reverseSideHopper.Space, sourceRectangle, Color.White);
        }
        public Boolean IsDead()
        {
            return false;
        }

        private void Jump()
        {

        }

    }
}

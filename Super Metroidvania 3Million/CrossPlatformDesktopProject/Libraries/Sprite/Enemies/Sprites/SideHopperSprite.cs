using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.InteropServices;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class SideHopperSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private int count;
        private int direction;
        private SideHopper sideHopper;
        public SideHopperSprite(Texture2D texture, SideHopper sh)
        {
            Texture = texture;
            Rows = 2;
            Columns = 6;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            sideHopper = sh;
            direction = 2;
        }

        public void Update(GameTime gameTime)
        {
            //change the frame after 20 counts
            if (!sideHopper.frozen)
            {
                if (count == 64)
                {
                    count = 0;
                    direction *= -1;
                    currentFrame++;
                    if (currentFrame == 3)
                    {
                        currentFrame = 0;
                    }
                }

                if (currentFrame == 2)
                {
                    sideHopper.Jump(count, direction);
                }
                count += 2;
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            if (sideHopper.damaged)
            {
                spriteBatch.Draw(Texture, sideHopper.Space, sourceRectangle, Color.Transparent);
                sideHopper.damaged = false;
            }
            else if (sideHopper.frozen)
            {
                spriteBatch.Draw(Texture, sideHopper.Space, sourceRectangle, Color.DodgerBlue);
            }
            else
            {
                spriteBatch.Draw(Texture, sideHopper.Space, sourceRectangle, Color.White);
            }
        }
        public Boolean IsDead()
        {
            return false;
        }


    }
}

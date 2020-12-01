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
        private int count;
        private Zeela zeela;

        public ZeelaSprite(Texture2D texture, Zeela z)
        {
            Texture = texture;
            Rows = 2;
            Columns = 4;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            count = 0;
            zeela = z;
        }

        public void Update(GameTime gameTime)
        {
            if (!zeela.frozen)
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
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            if (zeela.damaged)
            {
                spriteBatch.Draw(Texture, zeela.Space, sourceRectangle, Color.Transparent);
                zeela.damaged = false;
            }
            else if (zeela.frozen)
            {
                spriteBatch.Draw(Texture, zeela.Space, sourceRectangle, Color.DodgerBlue);
            }
            else
            {
                spriteBatch.Draw(Texture, zeela.Space, sourceRectangle, Color.White);
            }
        }

        public Boolean IsDead()
        {
            return false;
        }

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class RipperSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private Ripper ripper;

        public RipperSprite(Texture2D texture, Ripper r)
        {
            Texture = texture;
            Rows = 2;
            Columns = 1;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            ripper = r;
            
        }

        public void Update(GameTime gameTime)
        {
            //Stay on frame 0 (Frame 1 left for color change)
            currentFrame = 0;

          
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            spriteBatch.Draw(Texture, ripper.Space, sourceRectangle, Color.White);
        }
        public Boolean IsDead()
        {
            return false;
        }

    }
}

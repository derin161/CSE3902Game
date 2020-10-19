using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Ripper : IEnemy
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private float x, y, initialX;
        private int direction;

        public Ripper(Texture2D texture, Vector2 location)
        {
            Texture = texture;
            Rows = 2;
            Columns = 1;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            x = location.X;
            initialX = location.X;
            y = location.Y;
            direction = 1;
        }

        public void Update(GameTime gameTime)
        {
            //Stay on frame 0 (Frame 1 left for color change)
            currentFrame = 0;

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

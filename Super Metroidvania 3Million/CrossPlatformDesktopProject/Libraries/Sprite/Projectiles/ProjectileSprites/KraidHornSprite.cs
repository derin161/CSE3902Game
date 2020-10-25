using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class KraidHornSprite : ISprite
    {

        private Texture2D texture;
        private KraidHorn horn;
        private int rows = 1;
        private int columns = 4;
        private int currentFrame = 0;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 50;


        public KraidHornSprite(Texture2D texture, KraidHorn kh)
        {
            // Need to set actual damage values at some point
            horn = kh;
            this.texture = texture;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //Determine the single frame width and height and the row and position of the current frame.
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            //Create source and destination and draw the sprite
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            spriteBatch.Draw(texture, horn.Space, sourceRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {

            //Only update the frames after each has been displayed for millisecondsPerFrame milliseconds.
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;

                //Advance the current frame and reset back to the first if at the final frame.
                currentFrame++;
                if (currentFrame == rows * columns)
                    currentFrame = 0;
            }

        }
    }
}

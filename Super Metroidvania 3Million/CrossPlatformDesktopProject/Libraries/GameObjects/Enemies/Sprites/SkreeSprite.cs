using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using CrossPlatformDesktopProject.Libraries.Container;


namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class SkreeSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private int count;
        private Skree skree;

        public SkreeSprite(Texture2D texture, Skree s)
        {
            Texture = texture;
            Rows = EnemyUtilities.SkreeSpriteRows;
            Columns = EnemyUtilities.SkreeSpriteColumns;
            currentFrame = 1;
            totalFrames = Rows * Columns;
            count = 0;
            skree = s;
        }

        public void Update(GameTime gameTime)
        {
            if (!skree.frozen)
            {
                //change the frame after 10 counts while skree is falling
                if (skree.fallen && !skree.collision && count == EnemyUtilities.SkreeSpriteFrameSpeed)
                {
                    count = 0;
                    currentFrame++;
                    if (currentFrame == EnemyUtilities.SkreeSpriteFrameReset)
                    {
                        currentFrame = 0;
                    }
                }
                count = (count + 1) % EnemyUtilities.SkreeSpriteFrameSpeed + 1;

            }
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);

            if (skree.damaged)
            {
                spriteBatch.Draw(Texture, skree.Space, sourceRectangle, Color.Transparent);
                skree.damaged = false;
            }
            else if (skree.frozen)
            {
                spriteBatch.Draw(Texture, skree.Space, sourceRectangle, Color.DodgerBlue);
            }
            else
            {
                spriteBatch.Draw(Texture, skree.Space, sourceRectangle, Color.White);
            }
        }
        public Boolean IsDead()
        {
            return false;
        }

    }
}

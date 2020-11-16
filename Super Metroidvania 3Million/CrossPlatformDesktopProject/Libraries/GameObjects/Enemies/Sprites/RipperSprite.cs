using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using CrossPlatformDesktopProject.Libraries.Container;


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
        private EnemyUtilities EnemyUtilities = InfoContainer.Instance.Enemies;


        public RipperSprite(Texture2D texture, Ripper r)
        {
            Texture = texture;
            Rows = EnemyUtilities.RipperSpriteRows;
            Columns = EnemyUtilities.RipperSpriteColumns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            ripper = r;
            
        }

        public void Update(GameTime gameTime)
        {
            //Stay on frame 0
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

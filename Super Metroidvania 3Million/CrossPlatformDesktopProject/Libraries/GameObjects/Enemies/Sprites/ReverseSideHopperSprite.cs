using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SuperMetroidvania5Million.Libraries.Container;


namespace SuperMetroidvania5Million.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class ReverseSideHopperSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;
        private int count;
        private int direction;
        private ReverseSideHopper reverseSideHopper;
        private EnemyUtilities EnemyUtilities = InfoContainer.Instance.Enemies;

        public ReverseSideHopperSprite(Texture2D texture, ReverseSideHopper rsh)
        {
            Texture = texture;
            Rows = EnemyUtilities.SidehopperSpriteRows;
            Columns = EnemyUtilities.SidehopperSpriteColumns;
            currentFrame = 3;
            totalFrames = Rows * Columns;
            reverseSideHopper = rsh;
            direction = 2;
        }

        public void Update(GameTime gameTime)
        {
            if (!reverseSideHopper.frozen)
            {
                //change the frame after 20 counts
                if (count == EnemyUtilities.SidehopperSpriteFrameSpeed)
                {
                    count = 0;
                    direction *= -1;
                    currentFrame++;
                    if (currentFrame == EnemyUtilities.ReverseSidehopperSpriteFrameReset)
                    {
                        currentFrame = 3;
                    }
                }

                //Jump while on frame 5
                if (currentFrame == EnemyUtilities.ReverseSidehopperSpriteFrameReset - 1)
                {
                    reverseSideHopper.Jump(count, direction);
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

            if (reverseSideHopper.damaged)
            {
                spriteBatch.Draw(Texture, reverseSideHopper.Space, sourceRectangle, Color.Transparent);
                reverseSideHopper.damaged = false;
            }
            else if (reverseSideHopper.frozen)
            {
                spriteBatch.Draw(Texture, reverseSideHopper.Space, sourceRectangle, Color.DodgerBlue);
            }
            else
            {
                spriteBatch.Draw(Texture, reverseSideHopper.Space, sourceRectangle, Color.White);
            }
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

using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class VerticalZeela : IGameObject
    {

        private ISprite sprite;
        private float x, y, initialY;
        private int direction;
        public Rectangle Space;
        public VerticalZeela(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.VerticalZeelaSprite(this);
            x = location.X;
            initialY = location.Y;
            y = location.Y;
            direction = 1;
        }

        public void Update(GameTime gameTime)
        {
            //Move up and down
            y += direction;
            if (Math.Abs(y - initialY) > 100)
            {
                direction *= -1;
            }
            Space = new Rectangle((int)x, (int)y, 32, 32);
            sprite.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public Boolean IsDead()
        {
            return false;
        }



    }
}

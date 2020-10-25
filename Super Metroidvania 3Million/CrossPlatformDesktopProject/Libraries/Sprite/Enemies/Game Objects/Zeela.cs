using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Zeela : IGameObject
    {

        private ISprite sprite;
        private float x, y, initialX;
        private int direction;
        public Rectangle Space;
        public Zeela(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.ZeelaSprite(this);
            x = location.X;
            initialX = location.X;
            y = location.Y;
            direction = 1;
        }

        public void Update(GameTime gameTime)
        {
            //Move horizontally back and forth across the screen
            x += direction;
            if (Math.Abs(x - initialX) > 100)
            {
                direction *= -1;
            }
            Space = new Rectangle((int)x, (int)y, 32, 32);
            sprite.Update(gameTime);
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
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

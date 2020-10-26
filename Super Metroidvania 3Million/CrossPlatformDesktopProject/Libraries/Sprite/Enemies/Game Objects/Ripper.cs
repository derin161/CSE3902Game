using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Ripper : IEnemy
    {

        private ISprite sprite;
        private float x, y, initialX;
        private int direction;
        public Rectangle Space;
        private bool isDead;
        public Ripper(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.RipperSprite(this);
            x = location.X;
            initialX = location.X;
            y = location.Y;
            direction = 1;
        }

        public void Update(GameTime gameTime)
        {
            //move back and forth in x direction
            x += direction;
            if (Math.Abs(x - initialX) > 100)
            {
                direction *= -1;
            }

            Space = new Rectangle((int)x, (int)y, 32, 16);
            sprite.Update(gameTime);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public Boolean IsDead()
        {
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
        }


    }
}

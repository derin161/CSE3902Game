using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class ReverseSideHopper : IEnemy
    {

        private ISprite sprite;
        public Rectangle Space;
        private float x, y, initialX, initialY;
        private bool isDead;
        public ReverseSideHopper(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.ReverseSideHopperSprite(this);
            x = location.X;
            y = location.Y;
            initialX = location.X;
            initialY = location.Y;
        }

        public void Update(GameTime gameTime)
        {
            Space = new Rectangle((int)x, (int)y, 48, 52);
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

        public void Jump(int count, int direction)
        {
            y = -(count * count) + 20 * count + initialY;
            x += direction;
        }

    }
}

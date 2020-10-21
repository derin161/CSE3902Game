using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Skree : IGameObject
    {

        private ISprite sprite;
        private float x, y, initialY;
        public Rectangle Space;

        public Skree(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.SkreeSprite(this);
            x = location.X;
            y = location.Y;
            initialY = location.Y;
        }

        public void Update(GameTime gameTime)
        {
            //Move to the ground (410) and then reset
            y += 2;
            if (y > 410)
            {
                y = initialY;
            }

            Space = new Rectangle((int)x, (int)y, 32, 48);

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

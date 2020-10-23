using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Geega : IGameObject
    {
        private ISprite sprite;
        private float x, y;
        private float initialX;
        public Rectangle Space { get; set; }
        public Geega(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.GeegaSprite(this);
            x = location.X;
            y = location.Y;
            initialX = location.X;
        }

        public void Update(GameTime gameTime)
        {
            //Update the position of the sprite
            x -= 3;
            if (initialX - x > 300)
            {
                x = initialX;
            }

            Space = new Rectangle((int)x, (int)y, 32,32);
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

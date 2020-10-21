using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class Geega : IGameObject
    {
        private ISprite sprite;
        public Geega(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.GeegaSprite(location);
        }

        public void Update(GameTime gameTime)
        {
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

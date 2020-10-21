using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites
{
    //Author: Will Floyd
    class ReverseSideHopper : IGameObject
    {

        private ISprite sprite;
        public ReverseSideHopper(Vector2 location)
        {
            sprite = EnemySpriteFactory.Instance.ReverseSideHopperSprite(location);
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

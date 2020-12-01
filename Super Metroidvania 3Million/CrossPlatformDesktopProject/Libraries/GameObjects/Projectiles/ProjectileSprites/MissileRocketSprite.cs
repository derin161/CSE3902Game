using CrossPlatformDesktopProject.Libraries.Container;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class MissileRocketSprite : ISprite
    {
        private Texture2D texture;
        private MissileRocket missileRocket;
        private Rectangle srcRect;
        private ProjectileUtilities projInfo = InfoContainer.Instance.Projectiles;

        public MissileRocketSprite(Texture2D texture, MissileRocket mr, bool isHorizontal)
        {
            this.texture = texture;
            missileRocket = mr;
            int x = projInfo.MissileRocketHorizontalSpriteX;
            int y = projInfo.MissileRocketHorizontalSpriteY;
            int width = projInfo.MissileRocketHorizontalSpaceWidth;
            int height = projInfo.MissileRocketHorizontalSpaceHeight;
            if (!isHorizontal)
            {
                x = projInfo.MissileRocketVerticalSpriteX;
                y = projInfo.MissileRocketVerticalSpriteY;
                width = projInfo.MissileRocketHorizontalSpaceHeight;
                height = projInfo.MissileRocketHorizontalSpaceWidth;
            }
            srcRect = new Rectangle(x, y, width, height);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 center = new Vector2(srcRect.Width / 2, srcRect.Height / 2);
            if (missileRocket.Direction.X >= 0)
            {
                spriteBatch.Draw(texture, missileRocket.Space, srcRect, Color.White, 0, center, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                spriteBatch.Draw(texture, missileRocket.Space, srcRect, Color.White);
            }


        }

        public void Update(GameTime gameTime)
        {
            //Nothing to do here.
        }
    }
}

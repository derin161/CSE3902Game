using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class MissleRocketItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private MissleRocketItem missleRocketItem;

        public MissleRocketItemSprite(Texture2D texture, MissleRocketItem m)
        {
            Texture = texture;
            missleRocketItem = m;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, missleRocketItem.Space, Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}

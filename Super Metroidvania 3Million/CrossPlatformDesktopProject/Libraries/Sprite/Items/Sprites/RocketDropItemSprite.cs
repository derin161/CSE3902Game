using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class RocketDropItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private RocketDropItem rocketDropItem;

        public RocketDropItemSprite(Texture2D texture, RocketDropItem r)
        {
            Texture = texture;
            rocketDropItem = r;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, rocketDropItem.Space, Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}

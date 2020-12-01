using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Sprite.Items.Sprites
{
    class UpgradeItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private IItem upgradeItem;

        public UpgradeItemSprite(Texture2D texture, IItem u)
        {
            Texture = texture;
            upgradeItem = u;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, upgradeItem.SpaceRectangle(), Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class EnergyDropItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private EnergyDropItem energyDropItem;

        public EnergyDropItemSprite(Texture2D texture, EnergyDropItem ed)
        {
            Texture = texture;
            energyDropItem = ed;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, energyDropItem.Space, Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}

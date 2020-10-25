using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class EnergyTankItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private EnergyTankItem energyTankItem;

        public EnergyTankItemSprite(Texture2D texture, EnergyTankItem et)
        {
            Texture = texture;
            energyTankItem = et;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, energyTankItem.Space, Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}

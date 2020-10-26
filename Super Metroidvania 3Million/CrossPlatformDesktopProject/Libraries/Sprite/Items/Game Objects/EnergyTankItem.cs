using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class EnergyTankItem : IItem
    {
        private ISprite sprite;
        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }

        public EnergyTankItem(Vector2 initialLocation)
        {
            sprite = ItemSpriteFactory.Instance.EnergyTankItemSprite(this);
            Location = initialLocation;
            Space = new Rectangle((int)Location.X, (int)Location.Y, 16, 16);
        }

        public void Update(GameTime gameTime)
        {
            Space = new Rectangle((int)Location.X, (int)Location.Y, Space.Width, Space.Height);
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public bool IsDead()
        {
            return false;
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }
    }
}

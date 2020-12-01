using SuperMetroidvania5Million.Libraries.SFactory;
using SuperMetroidvania5Million.Libraries.Sprite.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Sprite.Items
{
    public class HiddenPuzzles : IItem
    {
        private bool isDead = false;
        private ISprite sprite;
        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }

        public HiddenPuzzles(Vector2 initialLocation)
        {
            sprite = ItemSpriteFactory.Instance.HiddenPuzzlesSprite(this);
            Location = initialLocation;
            Space = new Rectangle((int)Location.X, (int)Location.Y, 32, 32);
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
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public void GiveToPlayer(PlayerInventory pInventory)
        {
            pInventory.GiveItem(this);
        }
    }
}

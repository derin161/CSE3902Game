using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class HighJumpItem : IItem
    {
        private ISprite sprite;
        private float xLoc = 0;
        private float yLoc = 0;
        public Rectangle Space { get; set; }

        public HighJumpItem(Vector2 initialLocation)
        {
            sprite = ItemSpriteFactory.Instance.HighJumpItemSprite(this);
            xLoc = initialLocation.X;
            yLoc = initialLocation.Y;
        }


        public void Update(GameTime gameTime)
        {

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

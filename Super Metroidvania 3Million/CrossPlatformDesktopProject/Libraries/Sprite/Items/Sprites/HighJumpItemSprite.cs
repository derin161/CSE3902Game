using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class HighJumpItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private HighJumpItem highJumpItem;

        public HighJumpItemSprite(Texture2D texture, HighJumpItem h)
        {
            Texture = texture;
            highJumpItem = h;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, highJumpItem.Space, Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class LongBeamItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private LongBeamItem longBeamItem;

        public LongBeamItemSprite(Texture2D texture, LongBeamItem l)
        {
            Texture = texture;
            longBeamItem = l;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, longBeamItem.Space, Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}

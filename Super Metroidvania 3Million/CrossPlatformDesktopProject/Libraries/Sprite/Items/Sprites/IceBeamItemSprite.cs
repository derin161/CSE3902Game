using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class IceBeamItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private IceBeamItem iceBeamItem;

        public IceBeamItemSprite(Texture2D texture, IceBeamItem i)
        {
            Texture = texture;
            iceBeamItem = i;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, iceBeamItem.Space, Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}

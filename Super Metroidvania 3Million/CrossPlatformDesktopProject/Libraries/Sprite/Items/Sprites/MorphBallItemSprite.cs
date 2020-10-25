using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class MorphBallItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private MorphBallItem morphBallItem;

        public MorphBallItemSprite(Texture2D texture, MorphBallItem m)
        {
            Texture = texture;
            morphBallItem = m;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, morphBallItem.Space, Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}

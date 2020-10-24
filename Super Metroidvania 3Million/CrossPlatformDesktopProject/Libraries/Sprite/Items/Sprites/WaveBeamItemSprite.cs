using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class WaveBeamItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        private WaveBeamItem waveBeamItem;

        public WaveBeamItemSprite(Texture2D texture, WaveBeamItem w)
        {
            Texture = texture;
            waveBeamItem = w;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, waveBeamItem.Space, Color.White);
        }

        public bool IsDead()
        {
            return false;
        }
    }
}

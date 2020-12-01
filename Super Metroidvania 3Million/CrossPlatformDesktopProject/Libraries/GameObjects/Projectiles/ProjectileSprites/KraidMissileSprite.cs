using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class KraidMissileSprite : ISprite
    {
        private Texture2D texture;
        private KraidMissile kraidMissile;

        public KraidMissileSprite(Texture2D texture, KraidMissile km)
        {
            kraidMissile = km;
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRec = new Rectangle(0, 0, texture.Width, texture.Height);
            spriteBatch.Draw(texture, kraidMissile.Space, sourceRec, Color.White);

        }

        public void Update(GameTime gameTime)
        {
            //nothing to do here
        }
    }
}

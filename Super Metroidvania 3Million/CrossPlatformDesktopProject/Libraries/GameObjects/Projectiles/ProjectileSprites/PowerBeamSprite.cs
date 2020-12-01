using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class PowerBeamSprite : ISprite
    {
        private Texture2D texture;
        private PowerBeam beam;

        public PowerBeamSprite(Texture2D texture, PowerBeam pb)
        {
            beam = pb;
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRec = new Rectangle(0, 0, texture.Width / 2, texture.Height / 2); //Texture before collision

            //Change texture if projectile has collided or run out.
            if (beam.IsDead())
            {
                sourceRec = new Rectangle(texture.Width / 2, texture.Height / 2, texture.Width / 2, texture.Height / 2); //Texture after collision
            }

            spriteBatch.Draw(texture, beam.Space, sourceRec, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Nothing to do here.

        }
    }
}

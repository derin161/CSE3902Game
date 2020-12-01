using CrossPlatformDesktopProject.Libraries.Container;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class WaveBeamSprite : ISprite
    {
        private Texture2D texture;
        private WaveBeam beam;
        private Queue<Rectangle> waveSpaceSequence = new Queue<Rectangle>();
        private int time = 0;
        private ProjectileUtilities projInfo = InfoContainer.Instance.Projectiles;


        public WaveBeamSprite(Texture2D texture, WaveBeam wb)
        {
            beam = wb;
            this.texture = texture;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRec = new Rectangle(0, 0, texture.Width / 2, texture.Height / 2); //Texture before collision

            //Change texture if projectile has collided or run out
            if (beam.IsDead())
            {
                sourceRec = new Rectangle(texture.Width / 2, texture.Height / 2, texture.Width / 2, texture.Height / 2); //Texture after collision
            }

            spriteBatch.Draw(texture, beam.Space, sourceRec, Color.White);
            if (time > projInfo.WaveBeamSpriteDelay)
            {
                spriteBatch.Draw(texture, waveSpaceSequence.Dequeue(), sourceRec, Color.White);
            }
        }

        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
            waveSpaceSequence.Enqueue(beam.Space);
        }
    }
}

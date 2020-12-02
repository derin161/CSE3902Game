using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMetroidvania5Million.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class WaveBeam : IProjectile
    {
        public Vector2 Location { get; set; }
        public Vector2 Direction { get; set; }
        public Rectangle Space { get; set; }

        private bool isDead = false;
        private Vector2 initialLocation;
        private bool isLongBeam;
        private bool isHorizontal;
        private ISprite sprite;
        private ProjectileUtilities projInfo = InfoContainer.Instance.Projectiles;


        public WaveBeam(Vector2 initialLocation, Vector2 direction, bool isLongBeam)
        {

            isHorizontal = (int)direction.Y == 0;
            Direction = direction;
            isDead = false;
            this.isLongBeam = isLongBeam;
            Location = initialLocation;
            this.initialLocation = initialLocation;
            Space = new Rectangle((int)Location.X, (int)Location.Y, projInfo.WaveBeamSpaceWidth, projInfo.WaveBeamSpaceHeight);
            sprite = ProjectilesSpriteFactory.Instance.CreateWaveBeamSprite(this);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {

            Vector2 relativePos = Vector2.Subtract(Location, initialLocation);

            float x = relativePos.X;
            float y = relativePos.Y;

            if (isHorizontal)
            {
                x += projInfo.WaveBeamDpos;
                if (Direction.X < 0) //If its moving to the left, then subtract 2x (to account for +x done earlier).
                {
                    x -= projInfo.WaveBeamDpos * 2;
                }
                y = (float)Math.Sin(Math.Abs(x)) * -projInfo.WaveBeamSinAmp; // Give projectile sinusiodal path
            }
            else
            {
                y -= projInfo.WaveBeamDpos;
                x = (float)Math.Sin(Math.Abs(y)) * projInfo.WaveBeamSinAmp; // Give projectile sinusiodal path
            }

            //Update position and Space
            relativePos = new Vector2(x, y);
            Location = Vector2.Add(initialLocation, relativePos);
            Space = new Rectangle((int)Location.X, (int)Location.Y, Space.Width, Space.Height);


            //If the Projectile is not a Long Beam, it dies after moving a set distance.
            if (!isLongBeam)
            {
                int bound = projInfo.ShortBeamBound;
                //Compare with isDead so the proj doesn't come back to life
                isDead = isDead || isHorizontal && (relativePos.X > bound || relativePos.X < -bound) || !isHorizontal && (relativePos.Y > bound || relativePos.Y < -bound);
            }
            else
            {
                //Die if a collision occurs or the projectile leaves the screen
                //Compare with isDead so the proj doesn't come back to life
                isDead = isDead || Location.X > 800 || Location.X < 0 || Location.Y > 480 || Location.Y < 0;
            }
            sprite.Update(gameTime);
        }

        public int GetDamage()
        {
            return projInfo.WaveBeamDamage;
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }
        public bool IsDead()
        {
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
        }
    }
}

using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class WaveBeam : IProjectile
    {
        public Vector2 Location { get; set; }
        public Vector2 Direction { get; set; }
        public int Damage { get; set; }
        public Rectangle Space { get; set; }

        private bool isDead = false;
        private Vector2 initialLocation;
        private bool isLongBeam;
        private bool isHorizontal;
        private ISprite sprite;


        public WaveBeam(Vector2 initialLocation, Vector2 direction, bool isLongBeam)
        {
            // Need to set actual damage values at some point
            if (isLongBeam)
            {
                Damage = 40;
            }
            else
            {
                Damage = 30;
            }

            isHorizontal = (int) direction.Y == 0;
            Direction = direction;
            isDead = false;
            this.isLongBeam = isLongBeam;
            Location = initialLocation;
            this.initialLocation = initialLocation;
            Space = new Rectangle((int)Location.X, (int)Location.Y, 8, 8);
            sprite = ProjectilesSpriteFactory.Instance.CreateWaveBeamSprite(this);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {

            //Using temporary var til collisions are added
            bool collision = false;

            Vector2 relativePos = Vector2.Subtract(Location, initialLocation);

            float x = relativePos.X;
            float y = relativePos.Y;

            if (isHorizontal)
            {
                x += 3;
                if (Direction.X < 0) //If its moving to the left, then subtract 6 (to account for +3 done earlier).
                {
                    x -= 6;
                }
                y = (float)Math.Sin(Math.Abs(x)) * -20; // Give projectile sinusiodal path
            }
            else
            {
                y -= 3;
                x = (float)Math.Sin(Math.Abs(y)) * 20; // Give projectile sinusiodal path
            }

            //Update position and Space
            relativePos = new Vector2(x, y);
            Location = Vector2.Add(initialLocation, relativePos);
            Space = new Rectangle((int) Location.X, (int) Location.Y, Space.Width, Space.Height);


            //If the Projectile is not a Long Beam, it dies after moving a set distance.
            if (!isLongBeam)
            {
                int boundX = 100;
                int boundY = 100;
                isDead = isDead || collision || isHorizontal && (relativePos.X > boundX || relativePos.X < -boundX) || !isHorizontal && (relativePos.Y > boundY || relativePos.Y < -boundY);
            }
            else {
                //Die if a collision occurs or the projectile leaves the screen
                isDead = isDead || collision || Location.X > 800 || Location.X < 0 || Location.Y > 480 || Location.Y < 0;
            }
            sprite.Update(gameTime);
        }

        public int GetDamage() {
            return Damage;
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }
        public bool IsDead() {
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
        }
    }
}

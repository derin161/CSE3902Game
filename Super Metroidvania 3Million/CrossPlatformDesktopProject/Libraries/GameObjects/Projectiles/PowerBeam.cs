using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class PowerBeam : IProjectile
    {
        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }
        public Vector2 Direction { get; set; }
        public bool IsIceBeam { get; set; }

        private bool isDead = false;
        private Vector2 initialLocation;
        private bool isLongBeam;
        private ISprite sprite;
        private ProjectileUtilities projInfo = InfoContainer.Instance.Projectiles;

        public PowerBeam(Vector2 initialLocation, Vector2 direction, bool isLongBeam, bool isIceBeam)
        {

            IsIceBeam = isIceBeam;
            this.isLongBeam = isLongBeam;
            Location = initialLocation;
            this.initialLocation = initialLocation;
            Direction = direction;
            Space = new Rectangle((int)Location.X, (int)Location.Y, projInfo.PowerBeamSpaceWidth, projInfo.PowerBeamSpaceHeight);
            if (isIceBeam)
            {
                sprite = ProjectilesSpriteFactory.Instance.CreateIceBeamSprite(this);
            }
            else
            {
                sprite = ProjectilesSpriteFactory.Instance.CreatePowerBeamSprite(this);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);

        }

        public void Update(GameTime gameTime)
        {


            //Update position and space rectangle
            Location = Vector2.Add(Location, Direction);
            Space = new Rectangle((int)Location.X, (int)Location.Y, Space.Width, Space.Height);

            //If the Projectile is not a Long Beam, it dies after moving a set distance.
            if (!isLongBeam)
            {

                //Determine relative position and the bounds
                int relativeX = (int)(Location.X - initialLocation.X);
                int relativeY = (int)(Location.Y - initialLocation.Y);
                int bound = projInfo.ShortBeamBound;
                //Compare with isDead so the proj doesn't come back to life
                isDead = isDead || relativeX > bound || relativeX < -bound || relativeY > bound || relativeY < -bound;

            }
            else
            {

                //Die if a collision occurs or the projectile leaves the screen
                //Compare with isDead so the proj doesn't come back to life
                isDead = isDead || Location.X > 800 || Location.X < 0 || Location.Y > 480 || Location.Y < 0;
            }

            sprite.Update(gameTime);
        }
        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public int GetDamage()
        {
            return projInfo.PowerBeamDamage;
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

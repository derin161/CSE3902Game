using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class KraidMissile : IProjectile
    {
        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }
        public Vector2 Direction { get; set; }

        private ISprite sprite;
        private bool isDead = false;
        private ProjectileUtilities projInfo = InfoContainer.Instance.Projectiles;

        public KraidMissile(Vector2 initialLocation, Vector2 direction)
        {
            Location = initialLocation;
            Direction = direction;
            Space = new Rectangle((int)Location.X, (int)Location.Y, projInfo.KraidMissileSpaceWidth, projInfo.KraidMissileSpaceHeight);
            sprite = ProjectilesSpriteFactory.Instance.CreateKraidMissileSprite(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            
        }

        public void Update(GameTime gameTime)
        {


            //Update position
            Location = Vector2.Add(Location, Direction);
            Space = new Rectangle((int)Location.X, (int)Location.Y, Space.Width, Space.Height);

            //Die if a collision occurs or the projectile leaves the screen
            isDead = isDead || Location.X > 800 || Location.X < 0 || Location.Y > 480 || Location.Y < 0;

            sprite.Update(gameTime);
        }
        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public int GetDamage()
        {
            return projInfo.KraidMissileDamage;
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

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
        public int Damage { get; set; }

        private ISprite sprite;
        private bool isDead = false;

        public KraidMissile(Vector2 initialLocation, Vector2 direction)
        {
            // Need to set actual damage values at some point
            Damage = 20;
            Location = initialLocation;
            Direction = direction;
            Space = new Rectangle((int)Location.X, (int)Location.Y, 16, 16);
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
            return Damage;
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

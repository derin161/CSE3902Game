using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class KraidHorn : IProjectile
    {
        public Vector2 Location { get; set; }
        public int Damage { get; set; }
        public Rectangle Space { get; set; }

        ISprite sprite;
        private bool isMovingRight;
        private Vector2 initialLocation;
        private bool isDead = false;


        public KraidHorn(Vector2 initialLocation, bool isMovingRight)
        {
            // Need to set actual damage values at some point
            Damage = 0;
            this.initialLocation = initialLocation;
            this.isMovingRight = isMovingRight;
            Location = initialLocation;
            Space = new Rectangle( (int) Location.X, (int) Location.Y, 16, 16);
            sprite = ProjectilesSpriteFactory.Instance.CreateKraidHornSprite(this);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);

        }

        public void Update(GameTime gameTime)
        {

            Vector2 relativePos = Vector2.Subtract(Location, initialLocation);
            float x = (float) relativePos.X + 3;
            float y = (float)(0.01 * x * x - 2 * x); // 1/100x^2 - 2x. Gives projectile parabolic path to the right.
            
            if (!isMovingRight) {
                x = (float) relativePos.X - 3;
                y = (float)(0.01 * x * x + 2 * x); // 1/100x^2 + 2x. Gives projectile parabolic path to the left.
            }

            //Update position and space
            relativePos = new Vector2(x, y);
            Location = Vector2.Add(initialLocation, relativePos);
            Space = new Rectangle((int)Location.X, (int)Location.Y, Space.Width, Space.Height);

            bool collision = false; //temp var til collisions are added

            //Die if a collision occurs or the projectile leaves the screen
            isDead = collision || Location.X > 800 || Location.X < 0 || Location.Y > 480 || Location.Y < 0;

            sprite.Update(gameTime);
        }

        public bool IsDead() {
            return isDead;
        }
    }
}

using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class MissileRocket : IProjectile
    {
        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }
        public Vector2 Direction { get; set; }
        public int Damage { get; set; }

        private ISprite sprite;
        private bool isHorizontal;
        private bool isDead = false;
        


        public MissileRocket(Vector2 initialLocation, Vector2 direction)
        {
            isHorizontal = (int) direction.Y == 0;
            Location = initialLocation;
            Direction = direction;
            Space = new Rectangle((int)Location.X, (int)Location.Y, 16, 8);
            if (!isHorizontal)
            {
                Space = new Rectangle((int)Location.X, (int)Location.Y, 8, 16);
            }
            sprite = ProjectilesSpriteFactory.Instance.CreateMissileRocketSprite(this, isHorizontal);
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

            //Using temporary var til collisions are added
            bool collision = false;

            //Die if a collision occurs or the projectile leaves the screen
            isDead = collision || Location.X > 800 || Location.X < 0 || Location.Y > 480 || Location.Y < 0;
            sprite.Update(gameTime);
        }
        public Rectangle SpaceRectangle()
        {
            return Space;
        }

        public bool IsDead() {
            return isDead;
        }
    }
}

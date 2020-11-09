using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class MissileRocketExplosion : IProjectile
    {
        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }
        public int Damage { get; set; }
        private ISprite sprite;
        private bool isActive = false;
        private bool isDead = false;
        private int time = 0;
        private int endTime = 100;


        public MissileRocketExplosion()
        {
            sprite = ProjectilesSpriteFactory.Instance.CreateMissileRocketExplosionSprite(this);
            Damage = 0;
            Space = new Rectangle((int)Location.X, (int)Location.Y, 0, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                sprite.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (isActive)
            {
                //Update space rectangle to allow for collisions
                time += gameTime.ElapsedGameTime.Milliseconds;
                isDead = time > endTime;
                sprite.Update(gameTime);
            }
        }
        public void Activate(Vector2 location)
        {
            Location = location;
            isActive = true;
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

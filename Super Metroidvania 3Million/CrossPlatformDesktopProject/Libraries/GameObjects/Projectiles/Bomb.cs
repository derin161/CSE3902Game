using CrossPlatformDesktopProject.Libraries.Audio;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class Bomb : IProjectile
    {

        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }
        public int Damage { get; set; }

        private ISprite sprite;
        private bool isDead = false;
        private int time = 0;
        private int boomTimer = 1000;
        private bool boomFlag = false;


        public Bomb(Vector2 location)
        {
            
            Damage = 100;
            Location = location;
            Space = new Rectangle((int)Location.X, (int)Location.Y, 0, 0); //Space rectangle initially empty to prevent collisions until explosion.
            sprite = ProjectilesSpriteFactory.Instance.CreatePreBoomBombSprite(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {

            isDead = boomFlag;

            time += gameTime.ElapsedGameTime.Milliseconds;
            if (!boomFlag && time > boomTimer)
            {
                sprite = ProjectilesSpriteFactory.Instance.CreatePostBoomBombSprite(this);
                Space = new Rectangle((int)Location.X, (int)Location.Y, 32, 32);
                boomFlag = true;
                SoundManager.Instance.Projectiles.ExplosionSound.PlaySound();
            }
            else if (!boomFlag){
                Space = new Rectangle((int)Location.X, (int)Location.Y, 0, 0);
            }

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

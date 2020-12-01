using SuperMetroidvania5Million.Libraries.Audio;
using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class Bomb : IProjectile
    {

        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }

        private ISprite sprite;
        private bool isDead = false;
        private int time = 0;
        private bool boomFlag = false;
        private ProjectileUtilities projInfo = InfoContainer.Instance.Projectiles;

        public Bomb(Vector2 location)
        {
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
            if (!boomFlag && time > projInfo.BombTimer)
            {
                sprite = ProjectilesSpriteFactory.Instance.CreatePostBoomBombSprite(this);
                Space = new Rectangle((int)Location.X, (int)Location.Y, projInfo.PostBombSpaceWidth, projInfo.PostBombSpaceHeight);
                boomFlag = true;
                SoundManager.Instance.Projectiles.ExplosionSound.PlaySound();
            }
            else if (!boomFlag)
            {
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
            return projInfo.BombDamage;
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

using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class KraidHorn : IProjectile
    {
        public Vector2 Location { get; set; }
        public Rectangle Space { get; set; }

        private ISprite sprite;
        private bool isMovingRight;
        private Vector2 initialLocation;
        private bool isDead = false;
        private ProjectileUtilities projInfo = InfoContainer.Instance.Projectiles;

        public KraidHorn(Vector2 initialLocation, bool isMovingRight)
        {
            this.initialLocation = initialLocation;
            this.isMovingRight = isMovingRight;
            Location = initialLocation;
            Space = new Rectangle((int)Location.X, (int)Location.Y, projInfo.KraidHornSpaceWidth, projInfo.KraidHornSpaceHeight);
            sprite = ProjectilesSpriteFactory.Instance.CreateKraidHornSprite(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            sprite.Draw(spriteBatch);

        }

        public void Update(GameTime gameTime)
        {

            Vector2 relativePos = Vector2.Subtract(Location, initialLocation);
            float x = (float)relativePos.X + projInfo.KraidHornDx;
            float y = (float)(projInfo.KraidHornArcA * x * x - projInfo.KraidHornArcB * x); //Gives projectile parabolic path to the right.

            if (!isMovingRight)
            {
                x = (float)relativePos.X - projInfo.KraidHornDx;
                y = (float)(projInfo.KraidHornArcA * x * x + projInfo.KraidHornArcB * x); //Gives projectile parabolic path to the left.
            }

            //Update position and space
            relativePos = new Vector2(x, y);
            Location = Vector2.Add(initialLocation, relativePos);
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
            return projInfo.KraidHornDamage;
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

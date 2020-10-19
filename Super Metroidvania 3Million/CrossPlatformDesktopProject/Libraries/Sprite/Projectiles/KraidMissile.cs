using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class KraidMissile : IProjectile
    {
        public Vector2 Location { get; set; }
        public Vector2 Direction { get; set; }
        public int Damage { get; set; }

        private Texture2D texture;
        private bool isDead = false;

        public KraidMissile(Texture2D texture, Vector2 initialLocation, Vector2 direction)
        {
            // Need to set actual damage values at some point
            Damage = 0;
            this.texture = texture;
            Location = initialLocation;
            Direction = direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            Rectangle destinationRec = new Rectangle((int)Location.X, (int)Location.Y, texture.Width*2, texture.Height*2);
            Rectangle sourceRec = new Rectangle(0, 0, texture.Width, texture.Height);
            spriteBatch.Draw(texture, destinationRec,sourceRec, Color.White);
            
        }

        public void Update(GameTime gameTime)
        {


            //Update position
            Location = Vector2.Add(Location, Direction);

            bool collision = false; //temp var til collisions are added

            //Die if a collision occurs or the projectile leaves the screen
            isDead = collision || Location.X > 800 || Location.X < 0 || Location.Y > 480 || Location.Y < 0;

        }

        public bool IsDead() {
            return isDead;
        }
    }
}

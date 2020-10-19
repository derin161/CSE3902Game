using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class PowerBeam : IProjectile
    {
        public Vector2 Location { get; set; }
        public Vector2 Direction { get; set; }
        public int Damage { get; set; }
        public bool IsIceBeam { get; set; }

        private bool isDead = false;
        private Texture2D texture;
        private Vector2 initialLocation;
        private bool isLongBeam;

        public PowerBeam(Texture2D texture, Vector2 initialLocation, Vector2 direction, bool isLongBeam, bool isIceBeam)
        {
            // Need to set actual damage values at some point
            if (isLongBeam)
            {
                Damage = 1;
            }
            else
            {
                Damage = 0;
            }

            IsIceBeam = isIceBeam;
            this.isLongBeam = isLongBeam;
            this.texture = texture;
            Location = initialLocation;
            this.initialLocation = initialLocation;
            Direction = direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            Rectangle destinationRec = new Rectangle((int)Location.X, (int)Location.Y, texture.Width / 2, texture.Height / 2);
            Rectangle sourceRec = new Rectangle(0, 0, texture.Width / 2, texture.Height / 2); //Texture before collision

            //Change texture if projectile has collided or run out
            if (isDead) {
                sourceRec = new Rectangle(texture.Width / 2, texture.Height / 2, texture.Width / 2, texture.Height / 2); //Texture after collision
            }

            spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Using temporary var til collisions are added
            bool collision = false;


            //Update position
            Location = Vector2.Add(Location, Direction);

            //If the Projectile is not a Long Beam, it dies after moving a set distance.
            if (!isLongBeam) {

                //Determine relative position and the bounds
                int relativeX = (int)(Location.X - initialLocation.X);
                int relativeY = (int)(Location.Y - initialLocation.Y);
                int boundX = 100;
                int boundY = 100;

                isDead = collision || relativeX > boundX || relativeX < -boundX || relativeY > boundY || relativeY < -boundY;

            } else {

                //Die if a collision occurs or the projectile leaves the screen
                isDead = collision || Location.X > 800 || Location.X < 0 || Location.Y > 480 || Location.Y < 0;
            }
            
        }

        public bool IsDead() {
            return isDead;
        }
    }
}

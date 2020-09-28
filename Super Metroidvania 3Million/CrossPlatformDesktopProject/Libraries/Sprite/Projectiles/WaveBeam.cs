using CrossPlatformDesktopProject.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class WaveBeam : IProjectile
    {
        public Vector2 Location { get; set; }
        public Vector2 Direction { get; set; }
        public int Damage { get; set; }
        public bool IsDead { get; set; }
        public bool IsIceBeam { get; set; }

        private Texture2D texture;
        private Vector2 initialLocation;
        private bool isLongBeam;
        private bool isHorizontal;
        private Queue<Vector2> wavePosSequence = new Queue<Vector2>();
        private int time = 0;


        public WaveBeam(Texture2D texture, Vector2 initialLocation, Vector2 direction, bool isLongBeam, bool isIceBeam)
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

            isHorizontal = (int) direction.Y == 0;
            if (isHorizontal)
            { //Make the wave oscillate up and down if horizontal
                Direction = Vector2.Add(direction, new Vector2(0, 1));
            }
            else { //Oscillate left to right
                Direction = Vector2.Add(direction, new Vector2(1, 0));
            }

            IsIceBeam = isIceBeam;
            IsDead = false;
            this.isLongBeam = isLongBeam;
            this.texture = texture;
            Location = initialLocation;
            this.initialLocation = initialLocation;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            Rectangle destinationRec1 = new Rectangle((int)Location.X, (int)Location.Y, texture.Width / 2, texture.Height / 2);
            Rectangle destinationRec2 = new Rectangle((int)Location.X, (int)Location.Y, texture.Width / 2, texture.Height / 2); //this value means nothing but can't be null
            wavePosSequence.Enqueue(Location);

            int i = 0;
            if (time > 100) //delay the second orb from appearing for a bit
            {

                Vector2 orb2Pos = wavePosSequence.Dequeue();
                destinationRec2 = new Rectangle((int)orb2Pos.X, (int)orb2Pos.Y, texture.Width / 2, texture.Height / 2);
            }

            Rectangle sourceRec = new Rectangle(0, 0, texture.Width / 2, texture.Height / 2); //Texture before collision

            //Change texture if projectile has collided or run out
            if (IsDead)
            {
                sourceRec = new Rectangle(texture.Width / 2, texture.Height / 2, texture.Width / 2, texture.Height / 2); //Texture after collision
            }

            spriteBatch.Draw(texture, destinationRec1, sourceRec, Color.White);
            if (time > 100) {
                spriteBatch.Draw(texture, destinationRec2, sourceRec, Color.White);
            }
        }

        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;

            //Using temporary var til collisions are added
            bool collision = false;
            if (collision)
            {
                IsDead = true;
            }


            //Update position
            Location = Vector2.Add(Location, Direction);

            //Determine relative position and the bounds
            int relativeX = (int)(Location.X - initialLocation.X);
            int relativeY = (int)(Location.Y - initialLocation.Y);
            int boundX = 100;
            int boundY = 100;

            if (isHorizontal) //Check if oscillation direction needs reversed.
            {
                boundY = 30;
                if (relativeY > boundY || relativeY < -boundY) {
                    Direction = Vector2.Multiply(Direction, new Vector2(1, -1));
                }
            }
            else
            {
                boundX = 30;
                if (relativeX > boundX || relativeX < -boundX)
                {
                    Direction = Vector2.Multiply(Direction, new Vector2(-1, 1));
                }
            }

            //If the Projectile is not a Long Beam, it dies after moving a set distance.
            if (!isLongBeam)
            {
                if (isHorizontal && (relativeX > boundX || relativeX < -boundX) || !isHorizontal && (relativeY > boundY || relativeY < -boundY))
                {
                    IsDead = true;
                }
            }

        }
    }
}

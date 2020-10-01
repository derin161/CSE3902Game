using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    //Author: Nyigel Spann
    public class MissleRocket : IProjectile
    {
        public Vector2 Location { get; set; }
        public Vector2 Direction { get; set; }
        public int Damage { get; set; }

        private Texture2D texture;
        private bool isHorizontal;
        private bool isDead = false;
        


        public MissleRocket(Texture2D texture, Vector2 initialLocation, Vector2 direction)
        {
            isHorizontal = (int)direction.Y == 0;
            this.texture = texture;
            Location = initialLocation;
            Direction = direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (isDead) { //Rocket has collided, explosion animation.
                
                
            }
            else { //Rocket still flying
                Rectangle destinationRec = new Rectangle((int)Location.X, (int)Location.Y, texture.Width / 2, texture.Height / 2);
                Rectangle sourceRec = new Rectangle(0, 4, 16, 8); //Horizontal texture before collision
                if (!isHorizontal)
                {
                    sourceRec = new Rectangle(17, 0, 8, 16); //Vertical texture before collision
                }
                spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White); 
            }

            
        }

        public void Update(GameTime gameTime)
        {
            //Using temporary var til collisions are added
            bool collision = false;
            if (collision) {
                isDead = true;
            }

            //Update position
            Location = Vector2.Add(Location, Direction);
            
        }

        public bool IsDead() {
            return isDead;
        }
    }
}

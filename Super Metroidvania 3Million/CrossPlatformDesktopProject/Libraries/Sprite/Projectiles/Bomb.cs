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
    public class Bomb : IProjectile
    {

        public Vector2 Location { get; set; }
        public int Damage { get; set; }

        private bool isDead = false;
        private Texture2D texture;
        private int time = 0;
        private int boomTimer = 1000;

        public Bomb(Texture2D texture, Vector2 location)
        {
            
            Damage = 0;
            this.texture = texture;
            Location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int frame = 0;

            //Change texture if projectile has collided or run out
            if (time < boomTimer ) {
                Rectangle srcRec = new Rectangle(0, 12, 8, 8); //Texture1 before boom
                if (frame % 2 != 0) {
                    srcRec = new Rectangle(9, 12, 8, 8); //Texture2 before boom
                }
                Rectangle destRec = new Rectangle((int)Location.X, (int)Location.Y, 8, 8);
                spriteBatch.Draw(texture, destRec, srcRec, Color.White);
                frame++;
            }
            else
            {
                int msPerFrame = 50;
                int boomFrame = (time - boomTimer) / msPerFrame;

                //Boom Animation 1
                Rectangle srcRec = new Rectangle(18, 8, 16, 16);
                Rectangle destRec = new Rectangle((int)Location.X, (int)Location.Y, 16, 16);
                
                if (boomFrame / msPerFrame == 1) //Boom Animation 2
                {
                    srcRec = new Rectangle(35, 8, 16, 16);
                } else if (boomFrame / msPerFrame == 2) //Boom Animation 3
                {
                    srcRec = new Rectangle(52, 0, 32, 32);
                    destRec = new Rectangle((int)Location.X, (int)Location.Y, 32, 32);
                }
                if (boomFrame < 3) {
                    spriteBatch.Draw(texture, destRec, srcRec, Color.White);
                } else {
                    IsDead = false;
                }
            }

        }

        public void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;
        }

        public bool IsDead() {
            return IsDead;
        }
    }
}

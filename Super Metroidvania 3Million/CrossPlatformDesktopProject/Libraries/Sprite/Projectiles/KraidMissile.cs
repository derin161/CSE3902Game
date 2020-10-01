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
    public class KraidMissile : IProjectile
    {
        public Vector2 Location { get; set; }
        public Vector2 Direction { get; set; }
        public int Damage { get; set; }

        private Texture2D texture;

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
            
            Rectangle destinationRec = new Rectangle((int)Location.X, (int)Location.Y, texture.Width, texture.Height);
            Rectangle sourceRec = new Rectangle(0, 0, texture.Width, texture.Height);
            spriteBatch.Draw(texture, destinationRec,sourceRec, Color.White);
            
        }

        public void Update(GameTime gameTime)
        {

            //Update position
            Location = Vector2.Add(Location, Direction);
            
        }
    }
}

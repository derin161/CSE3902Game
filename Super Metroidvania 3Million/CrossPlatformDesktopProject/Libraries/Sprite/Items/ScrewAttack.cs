using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class ScrewAttack : IItems
    {
        public Vector2 Location { get; set; }

        private Texture2D texture;
        private bool isDead = false;

        public ScrewAttack(Texture2D texture, Vector2 initialLocation)
        {
            this.texture = texture;
            Location = initialLocation;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(this.texture, new Vector2(Location.X, Location.Y), Color.White);
            spriteBatch.End();
        }

        public bool IsDead()
        {
            return isDead;
        }
    }
}

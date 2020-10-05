using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class RocketDropItem : IItems
    {
        private Texture2D texture;
        private int xLoc = 0;
        private int yLoc = 0;
        private bool isDead = false;

        public RocketDropItem(Texture2D texture, Vector2 initialLocation)
        {
            this.texture = texture;
            this.xLoc = (int)initialLocation.X;
            this.yLoc = (int)initialLocation.Y;
        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, new Vector2(this.xLoc, this.yLoc), Color.White);
        }

        public bool IsDead()
        {
            return isDead;
        }
    }
}

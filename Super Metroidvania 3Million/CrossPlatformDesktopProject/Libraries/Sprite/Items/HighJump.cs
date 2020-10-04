using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Items
{
    class HighJump : IItems
    {
        private Texture2D texture;
        private int xLoc = 0;
        private int yLoc = 0;
        private bool isDead = false;

        public HighJump(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            this.xLoc = x;
            this.yLoc = y;
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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Block
{
    class BlockSprite : BlockInterface
    {
        private Texture2D Texture;

        public BlockSprite(Texture2D Texture)
        {
            this.Texture = Texture;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(400 - Texture.Width/2, 240-Texture.Height/2, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);;
        }

        public bool IsDead() {
            return false;
        }

        
    }
}

﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Blocks
{
    class RedDoorBottomLeftBlockSprite : ISprite
    {
        private Texture2D texture;
        private RedDoorBottomLeftBlock block;

        public RedDoorBottomLeftBlockSprite(Texture2D texture, RedDoorBottomLeftBlock block)
        {
            this.block = block;
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            int width = texture.Width;
            int height = texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = block.Space;

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
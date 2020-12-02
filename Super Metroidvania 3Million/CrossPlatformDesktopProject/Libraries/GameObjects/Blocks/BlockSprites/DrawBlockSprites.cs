using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMetroidvania5Million.Libraries.Sprite.Blocks.BlockSprites
{
    class DrawBlockSprites : ISprite
    {
        private Texture2D texture;
        private IBlock block;

        public DrawBlockSprites(Texture2D texture, IBlock block)
        {
            this.block = block;
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            int width = texture.Width;
            int height = texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = block.SpaceRectangle();

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}

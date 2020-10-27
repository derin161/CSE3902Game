using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Blocks
{
    class BlockSprite : IBlock
    {
        private Texture2D Texture;
        private int xPos = 0;
        private int yPos = 0;
        public Rectangle Space { get; set; }
        private bool isDead = false;

        public BlockSprite(Texture2D Texture, Vector2 location)
        {
            this.Texture = Texture;
            this.xPos = (int)location.X;
            this.yPos = (int)location.Y;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(xPos, yPos, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

        public bool IsDead() {
            return isDead;
        }

        public void Kill()
        {
            isDead = true;
        }

        public Rectangle SpaceRectangle()
        {
            return Space;
        }
    }
}

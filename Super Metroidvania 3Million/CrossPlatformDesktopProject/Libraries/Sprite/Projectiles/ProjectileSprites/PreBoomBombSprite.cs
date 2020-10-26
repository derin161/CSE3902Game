using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Projectiles
{
    class PreBoomBombSprite : ISprite
    {
        private Bomb bomb;
        private int frame = 0;
        private Texture2D texture;

        public PreBoomBombSprite(Texture2D texture, Bomb b) {
            bomb = b;
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle srcRec = new Rectangle(0, 12, 8, 8); //Texture1 before boom
            if (frame % 2 != 0)
            {
                srcRec = new Rectangle(9, 12, 8, 8); //Texture2 before boom
            }
            //The bomb before exploding has an empty space, so cannot use it's space for destination rectangle.
            spriteBatch.Draw(texture, new Rectangle((int) bomb.Location.X, (int) bomb.Location.Y, 8, 8), srcRec, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            frame++;
        }
    }
}

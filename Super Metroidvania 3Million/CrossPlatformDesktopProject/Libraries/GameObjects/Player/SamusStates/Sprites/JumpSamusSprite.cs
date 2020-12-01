using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.Sprite.Player
{
    public class JumpSamusSprite : ISprite
    {
        public Texture2D texture { get; set; }
        private int rows;
        private int columns;
        private Samus samus;
        public int currentFrame { get; set; }
        public float origY { get; set; }

        public JumpSamusSprite(Texture2D text, Samus sus)
        {
            texture = text;
            samus = sus;
            rows = 1;
            columns = 1;
            currentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            //Nothing to Update
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = 0;
            int column = 0;

            Rectangle sourceRectangle = new Rectangle(column, row, width, height);
            spriteBatch.Draw(texture, samus.space, sourceRectangle, Color.White);
            currentFrame++;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class MenuBackgroundSprite : ISprite
    {
        private Rectangle space;
        private Texture2D texture;

        public MenuBackgroundSprite(Texture2D texture, Rectangle space)
        {
            this.space = space;
            this.texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, space, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Nothing to do
        }
    }
}

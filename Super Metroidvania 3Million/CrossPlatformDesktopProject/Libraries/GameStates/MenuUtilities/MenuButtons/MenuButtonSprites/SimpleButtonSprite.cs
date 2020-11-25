using CrossPlatformDesktopProject.Libraries.Container;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class SimpleButtonSprite : ISprite
    {
        private IMenuButton button;
        private String text;

        public SimpleButtonSprite(IMenuButton menuButton, String buttonText) {
            button = menuButton;
            text = buttonText;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            //Nothing to do
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class AudioSettingsMenuButton : IMenuButton
    {
        public Rectangle Space { get; private set; }

        public AudioSettingsMenuButton(Rectangle space) {
            Space = space;
        }

        public void Left()
        {
            //Do nothing
        }

        public void Press()
        {
            throw new NotImplementedException();
        }

        public void Right()
        {
            //Do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}

using CrossPlatformDesktopProject.Libraries.Container;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class ResumeMenuButton : IMenuButton
    {
        public Rectangle Space { get; private set; }
        private ISprite sprite;

        public ResumeMenuButton(Rectangle space) {
            Space = space;
            sprite = new SimpleButtonSprite(this, "RESUME");
        }

        public void Left()
        {
            //Do nothing
        }

        public void Press()
        {
            GameStateMachine.Instance.Play();
        }

        public void Right()
        {
            //Do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}

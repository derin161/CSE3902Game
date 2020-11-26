using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class SettingsMenuButton : IMenuButton
    {
        public Rectangle Space { get; private set; }
        public bool IsSelected { get; set; } = false;

        private ISprite sprite;

        public SettingsMenuButton(Rectangle space) {
            Space = space;
            sprite = MenuSpriteFactory.Instance.CreateSimpleButtonSprite(this, "SETTINGS");
        }

        public void Left()
        {
            //Do nothing
        }

        public void Press()
        {
            //TODO: Take user to settings screen.
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

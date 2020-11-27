using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class SettingsTabMenuButton : IMenuButton
    {
        public Rectangle Space { get; private set; }
        public bool IsSelected { get; set; } = false;

        private SettingsMenuState settingsMenu;
        private ISprite sprite;

        public SettingsTabMenuButton(Rectangle space, String buttonText, SettingsMenuState settingsMenuState) {
            Space = space;
            sprite = MenuSpriteFactory.Instance.CreateSimpleButtonSprite(this, buttonText);
            settingsMenu = settingsMenuState;
        }

        public void Left()
        {
            settingsMenu.TabButtonList[settingsMenu.TabButtonIndex].IsSelected = false;
            settingsMenu.TabButtonIndex = (((settingsMenu.TabButtonIndex - 1) % settingsMenu.TabButtonList.Count) + settingsMenu.TabButtonList.Count) % settingsMenu.TabButtonList.Count; //Mod that works for negative numbers
            settingsMenu.TabButtonList[settingsMenu.TabButtonIndex].IsSelected = true;
        }

        public void Press()
        {
            //Do nothing
        }

        public void Right()
        {
            settingsMenu.TabButtonList[settingsMenu.TabButtonIndex].IsSelected = false;
            settingsMenu.TabButtonIndex = (settingsMenu.TabButtonIndex + 1) % settingsMenu.TabButtonList.Count;
            settingsMenu.TabButtonList[settingsMenu.TabButtonIndex].IsSelected = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}

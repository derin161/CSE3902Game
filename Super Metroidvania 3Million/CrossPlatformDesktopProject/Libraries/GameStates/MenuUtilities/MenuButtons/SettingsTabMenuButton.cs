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
        private ICommand pressCommand;

        public SettingsTabMenuButton(String buttonText, Rectangle space, SettingsMenuState settingsMenuState)
        {
            Space = space;
            sprite = MenuSpriteFactory.Instance.CreateSimpleButtonSprite(this, buttonText);
            settingsMenu = settingsMenuState;
            this.pressCommand = new DummyCommand();
        }

        public SettingsTabMenuButton(String buttonText, Rectangle space, SettingsMenuState settingsMenuState, ICommand pressCommand)
        {
            Space = space;
            sprite = MenuSpriteFactory.Instance.CreateSimpleButtonSprite(this, buttonText);
            settingsMenu = settingsMenuState;
            this.pressCommand = pressCommand;
        }

        public SettingsTabMenuButton(String buttonText, Vector2 point, SettingsMenuState settingsMenuState)
        {
            Space = new Rectangle(point.ToPoint(), MenuSpriteFactory.Instance.LargeDefaultFont.MeasureString(buttonText).ToPoint());
            sprite = MenuSpriteFactory.Instance.CreateSimpleButtonSprite(this, buttonText);
            settingsMenu = settingsMenuState;
            this.pressCommand = new DummyCommand();
        }

        public SettingsTabMenuButton(String buttonText, Vector2 point, SettingsMenuState settingsMenuState, ICommand pressCommand)
        {
            Space = new Rectangle(point.ToPoint(), MenuSpriteFactory.Instance.LargeDefaultFont.MeasureString(buttonText).ToPoint());
            sprite = MenuSpriteFactory.Instance.CreateSimpleButtonSprite(this, buttonText);
            settingsMenu = settingsMenuState;
            this.pressCommand = pressCommand;
        }

        public void Left()
        {
            settingsMenu.TabButtonList[settingsMenu.TabButtonIndex].IsSelected = false;
            settingsMenu.TabButtonIndex = (((settingsMenu.TabButtonIndex - 1) % settingsMenu.TabButtonList.Count) + settingsMenu.TabButtonList.Count) % settingsMenu.TabButtonList.Count; //Mod that works for negative numbers
            settingsMenu.TabButtonList[settingsMenu.TabButtonIndex].IsSelected = true;
        }

        public void Press()
        {
            pressCommand.Execute();
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

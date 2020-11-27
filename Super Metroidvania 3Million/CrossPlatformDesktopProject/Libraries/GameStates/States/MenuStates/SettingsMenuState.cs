using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class SettingsMenuState : AbstractMenuState
    {
        public Dictionary<IMenuButton, List<IMenuButton>> TabButtonsToSubMenuButtons { get; private set; } = new Dictionary<IMenuButton, List<IMenuButton>>();
        public List<IMenuButton> TabButtonList { get; private set; } = new List<IMenuButton>();
        public int TabButtonIndex { get; set; } = 0;

        private ISprite menuBackground;
        private ICommand exitCommand;
        private int tabButtonWidth;
        private int tabButtonHeight;
        private int tabButtonXPos;
        private int tabButtonYPos;


        public SettingsMenuState(Game1 game, IMenuState backMenuState) {

            exitCommand = new SetMenuStateCommand(backMenuState);   

            int menuWidth = 800;
            int menuHeight = 480;
            menuBackground = MenuSpriteFactory.Instance.CreateSimpleBackgroundSprite(new Rectangle(0, 0, menuWidth, menuHeight));



            tabButtonWidth = 60;
            tabButtonHeight = 20;
            tabButtonXPos = 20;
            tabButtonYPos = 20;
            IMenuButton backButton = generateTabButtonAndList("BACK");

            generateGameSettings();
            generateAudioSettings();

            ButtonList = TabButtonsToSubMenuButtons[backButton];
            ButtonList[0].IsSelected = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            menuBackground.Draw(spriteBatch);
            foreach (IMenuButton button in ButtonList) {
                button.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            ButtonList = TabButtonsToSubMenuButtons[TabButtonList[TabButtonIndex]];
        }

        public override void ExitMenu()
        {
            exitCommand.Execute();
        }

        private void generateGameSettings() {
            tabButtonXPos += tabButtonWidth * 2;
            IMenuButton tabButton = generateTabButtonAndList("GAME SETTINGS");

        }

        private void generateAudioSettings()
        {
            tabButtonXPos += tabButtonWidth * 2;
            IMenuButton tabButton = generateTabButtonAndList("AUDIO SETTINGS");
        }

        private IMenuButton generateTabButtonAndList(String tabButtonText) {
            Rectangle tabButtonRectangle = new Rectangle(tabButtonXPos, tabButtonYPos, tabButtonWidth, tabButtonHeight);
            IMenuButton tabButton = new SettingsTabMenuButton(tabButtonRectangle, tabButtonText, this);
            TabButtonsToSubMenuButtons.Add(tabButton, new List<IMenuButton>());
            TabButtonsToSubMenuButtons[tabButton].Add(tabButton);
            TabButtonList.Add(tabButton);
            return tabButton;
        }
    }
}

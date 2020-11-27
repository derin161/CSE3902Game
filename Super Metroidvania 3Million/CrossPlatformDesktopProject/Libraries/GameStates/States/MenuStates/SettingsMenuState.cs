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
        private int buttonWidth = 60;
        private int buttonHeight = 20;
        private int buttonXPos;
        private int buttonYPos = 80;


        public SettingsMenuState(Game1 game, IMenuState backMenuState) {

            exitCommand = new SetMenuStateCommand(backMenuState);   

            int menuWidth = 800;
            int menuHeight = 480;
            menuBackground = MenuSpriteFactory.Instance.CreateSimpleBackgroundSprite(new Rectangle(0, 0, menuWidth, menuHeight));

            tabButtonWidth = 100;
            tabButtonHeight = 20;
            tabButtonXPos = 20;
            tabButtonYPos = 20;

            buttonWidth = 60;
            buttonHeight = 20;
            buttonXPos = 800 / 2 - buttonWidth / 2;
            buttonYPos = 80;

            IMenuButton backButton = generateTabButtonAndList("BACK");

            generateGameSettings(game);
            generateAudioSettings();

            ButtonList = TabButtonsToSubMenuButtons[backButton];
            ButtonList[0].IsSelected = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            menuBackground.Draw(spriteBatch);

            //The selected tabButton will get drawn twice but who cares.
            foreach (IMenuButton button in ButtonList) {
                button.Draw(spriteBatch);
            }
            foreach (IMenuButton tabButton in TabButtonList) {
                tabButton.Draw(spriteBatch);
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

        private void generateGameSettings(Game1 game) {
            tabButtonXPos += tabButtonWidth * 2;
            IMenuButton tabButton = generateTabButtonAndList("GAME SETTINGS");
            

            Rectangle buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            ICommand leftCommand = null;
            ICommand rightCommand = null;
            List<String> difficultyTexts = new List<string> { "Normal", "Hard" };
            TabButtonsToSubMenuButtons[tabButton].Add(new LeftRightMenuButton("DIFFICULTY", buttonRectangle, leftCommand, rightCommand, difficultyTexts));

            buttonYPos += buttonHeight * 2;
            buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            leftCommand = new ToggleFullscreenCommand(game);
            rightCommand = new ToggleFullscreenCommand(game);
            List<String> fullScreenTexts = new List<string> { "Off", "On" };
            TabButtonsToSubMenuButtons[tabButton].Add(new LeftRightMenuButton("FULLSCREEN", buttonRectangle, leftCommand, rightCommand, fullScreenTexts));

        }

        private void generateAudioSettings()
        {
            tabButtonXPos += tabButtonWidth * 2;
            IMenuButton tabButton = generateTabButtonAndList("AUDIO SETTINGS");
        }

        private IMenuButton generateTabButtonAndList(String tabButtonText) {
            Rectangle tabButtonRectangle = new Rectangle(tabButtonXPos, tabButtonYPos, tabButtonWidth, tabButtonHeight);
            IMenuButton tabButton = new SettingsTabMenuButton(tabButtonText, tabButtonRectangle, this);
            TabButtonsToSubMenuButtons.Add(tabButton, new List<IMenuButton>());
            TabButtonsToSubMenuButtons[tabButton].Add(tabButton);
            TabButtonList.Add(tabButton);
            return tabButton;
        }
    }
}

using SuperMetroidvania5Million.Libraries.Command;
using SuperMetroidvania5Million.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class SettingsMenuState : AbstractMenuState
    {
        public Dictionary<IMenuButton, List<IMenuButton>> TabButtonsToSubMenuButtons { get; private set; } = new Dictionary<IMenuButton, List<IMenuButton>>();
        public List<IMenuButton> TabButtonList { get; private set; } = new List<IMenuButton>();
        public int TabButtonIndex { get; set; } = 0;

        private ISprite menuBackground;
        private ICommand exitCommand;

        private int tabButtonXPos;
        private int tabButtonYPos;

        private int buttonWidth;
        private int buttonHeight;
        private int buttonXPos;
        private int buttonStartingYPos;
        private int buttonVerticalOffset;

        public SettingsMenuState(Game1 game, IMenuState backMenuState)
        {

            exitCommand = new SetMenuStateCommand(backMenuState);

            //I have no idea what is going on with the camera or what is going to be changed so this is not going to be drawn in the right location.
            menuBackground = MenuSpriteFactory.Instance.CreateSimpleBackgroundSprite(new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height));

            tabButtonXPos = 20;
            tabButtonYPos = 20;

            buttonWidth = 60;
            buttonHeight = 20;
            buttonStartingYPos = 80;
            buttonVerticalOffset = 40;

            buttonXPos = game.Window.ClientBounds.Size.X / 2 - buttonWidth / 2;

            IMenuButton backButton = generateTabButtonAndList("BACK", exitCommand);

            generateGameSettings(game);

            generateAudioSettings();

            ButtonList = TabButtonsToSubMenuButtons[backButton];
            ButtonList[0].IsSelected = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            menuBackground.Draw(spriteBatch);

            //The selected tabButton will get drawn twice but who cares.
            foreach (IMenuButton button in ButtonList)
            {
                button.Draw(spriteBatch);
            }
            foreach (IMenuButton tabButton in TabButtonList)
            {
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

        private void generateGameSettings(Game1 game)
        {
            IMenuButton tabButton = generateTabButtonAndList("GAME SETTINGS");

            int buttonYPos = buttonStartingYPos;
            Rectangle buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            ICommand leftCommand = new LowerDifficultyCommand();
            ICommand rightCommand = new RaiseDifficultyCommand();
            List<String> difficultyTexts = new List<string> { "Normal", "Hard" };
            TabButtonsToSubMenuButtons[tabButton].Add(new LeftRightMenuButton("DIFFICULTY", buttonRectangle, leftCommand, rightCommand, difficultyTexts));

            buttonYPos += buttonVerticalOffset;
            buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            leftCommand = new ToggleFullscreenCommand(game);
            rightCommand = new ToggleFullscreenCommand(game);
            List<String> fullScreenTexts = new List<string> { "Off", "On" };
            TabButtonsToSubMenuButtons[tabButton].Add(new LeftRightMenuButton("FULLSCREEN", buttonRectangle, leftCommand, rightCommand, fullScreenTexts));

        }

        private void generateAudioSettings()
        {
            IMenuButton tabButton = generateTabButtonAndList("AUDIO SETTINGS");

            int buttonYPos = buttonStartingYPos;
            Rectangle buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            ICommand leftCommand = new LowerSongVolumeCommand();
            ICommand rightCommand = new RaiseSongVolumeCommand();
            List<String> percentageTexts = new List<string> { "0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%" };
            int startingIndex = (int)(SongManager.Instance.Volume / SongManager.Instance.Controls.VolumeChange);
            TabButtonsToSubMenuButtons[tabButton].Add(new LeftRightMenuButton("SONG VOLUME", buttonRectangle, leftCommand, rightCommand, percentageTexts, startingIndex));

            buttonYPos += buttonVerticalOffset;
            buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            leftCommand = new LowerEffectVolumeCommand();
            rightCommand = new RaiseEffectVolumeCommand();
            startingIndex = (int)(SoundManager.Instance.EffectVolume / SoundManager.Instance.EffectVolumeChange);
            TabButtonsToSubMenuButtons[tabButton].Add(new LeftRightMenuButton("EFFECT VOLUME", buttonRectangle, leftCommand, rightCommand, percentageTexts, startingIndex));

            buttonYPos += buttonVerticalOffset;
            buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            leftCommand = new PlayPreviousThemeCommand();
            rightCommand = new PlayNextThemeCommand();
            startingIndex = SongManager.Instance.ActiveThemesNames.IndexOf(SongManager.Instance.ActiveSongName);
            TabButtonsToSubMenuButtons[tabButton].Add(new LeftRightMenuButton("ACTIVE SONG", buttonRectangle, leftCommand, rightCommand, SongManager.Instance.ActiveThemesNames, startingIndex));

            buttonYPos += buttonVerticalOffset;
            buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            leftCommand = new UnShuffleThemesCommand();
            rightCommand = new ShuffleThemesCommand();
            List<String> offOnTexts = new List<string> { "Off", "On" };
            if (SongManager.Instance.ShuffleMode)
            {
                startingIndex = 1;
            }
            else
            {
                startingIndex = 0;
            }
            TabButtonsToSubMenuButtons[tabButton].Add(new LeftRightMenuButton("SHUFFLE SONGS", buttonRectangle, leftCommand, rightCommand, offOnTexts, startingIndex));

            buttonYPos += buttonVerticalOffset;
            buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            leftCommand = new UnLoopCurrentThemeCommand();
            rightCommand = new LoopCurrentThemeCommand();
            if (SongManager.Instance.LoopMode)
            {
                startingIndex = 1;
            }
            else
            {
                startingIndex = 0;
            }
            TabButtonsToSubMenuButtons[tabButton].Add(new LeftRightMenuButton("LOOP ACTIVE SONG", buttonRectangle, leftCommand, rightCommand, offOnTexts, startingIndex));



        }

        private IMenuButton generateTabButtonAndList(String tabButtonText)
        {
            Vector2 tabButtonPos = new Vector2(tabButtonXPos, tabButtonYPos);
            IMenuButton tabButton = new SettingsTabMenuButton(tabButtonText, tabButtonPos, this);
            tabButtonXPos += tabButton.Space.Width + 40;

            TabButtonsToSubMenuButtons.Add(tabButton, new List<IMenuButton>());
            TabButtonsToSubMenuButtons[tabButton].Add(tabButton);
            TabButtonList.Add(tabButton);
            return tabButton;
        }

        private IMenuButton generateTabButtonAndList(String tabButtonText, ICommand pressCommand)
        {
            Vector2 tabButtonPos = new Vector2(tabButtonXPos, tabButtonYPos);
            IMenuButton tabButton = new SettingsTabMenuButton(tabButtonText, tabButtonPos, this, pressCommand);
            tabButtonXPos += tabButton.Space.Width + 40;

            TabButtonsToSubMenuButtons.Add(tabButton, new List<IMenuButton>());
            TabButtonsToSubMenuButtons[tabButton].Add(tabButton);
            TabButtonList.Add(tabButton);
            return tabButton;
        }
    }
}

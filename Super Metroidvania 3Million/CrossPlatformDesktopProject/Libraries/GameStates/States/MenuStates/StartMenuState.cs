using SuperMetroidvania5Million.Libraries.Command;
using SuperMetroidvania5Million.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.GameStates
{
    //Author: Will Floyd
    public class StartMenuState : AbstractMenuState
    {
        public List<IMenuButton> TabButtonList { get; private set; } = new List<IMenuButton>();
        public int TabButtonIndex { get; set; } = 0;

        private ISprite menuBackground;
        private ICommand exitCommand;
        private ICommand settingsMenuCommand;

        private int buttonWidth = 60;
        private int buttonXPos;
        private Game1 game;

        public StartMenuState(Game1 game)
        {
            this.game = game;

            menuBackground = MenuSpriteFactory.Instance.CreateSimpleBackgroundSprite(new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height));
            //game.EnterTheMainMenu();

            buttonXPos = game.Window.ClientBounds.Size.X / 2 - buttonWidth / 2;
            exitCommand = new QuitCommand(game);

            IMenuState settingsMenu = new SettingsMenuState(game, this);
            settingsMenuCommand = new SetMenuStateCommand(settingsMenu);

            generateStartMenu();

            ButtonList[0].IsSelected = true;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            menuBackground.Draw(spriteBatch);

            foreach (IMenuButton button in ButtonList)
            {
                button.Draw(spriteBatch);
            }
            
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void ExitMenu()
        {
            exitCommand.Execute();
        }

        private void generateStartMenu()
        {
            int buttonYPos = 230;
            int buttonYOffset = 50;

            SimpleMenuButton playButton = new SimpleMenuButton("Play", new Vector2(buttonXPos, buttonYPos), new PlayCommand(game));
            ButtonList.Add(playButton);
            buttonYPos += buttonYOffset;

            SimpleMenuButton DungeonBButton = new SimpleMenuButton("Dungeon B", new Vector2(buttonXPos, buttonYPos), new DungeonBCommand(game));
            ButtonList.Add(DungeonBButton);
            buttonYPos += buttonYOffset;

            SimpleMenuButton EndlessButton = new SimpleMenuButton("Endless Mode", new Vector2(buttonXPos, buttonYPos), new EndlessModeCommand(game));
            ButtonList.Add(EndlessButton);
            buttonYPos += buttonYOffset;

            SimpleMenuButton SettingsButton = new SimpleMenuButton("Settings", new Vector2(buttonXPos, buttonYPos), settingsMenuCommand);
            ButtonList.Add(SettingsButton);
            buttonYPos += buttonYOffset;

            SimpleMenuButton ExitButton = new SimpleMenuButton("Exit", new Vector2(buttonXPos, buttonYPos), exitCommand);
            ButtonList.Add(ExitButton);
        }

    }
}

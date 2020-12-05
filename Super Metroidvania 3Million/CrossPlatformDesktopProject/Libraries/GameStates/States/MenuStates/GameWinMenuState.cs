using SuperMetroidvania5Million.Libraries.Command;
using SuperMetroidvania5Million.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperMetroidvania5Million.Libraries.GameStates
{
    //Author: Will Floyd
    public class GameWinMenuState : AbstractMenuState
    {
        public List<IMenuButton> TabButtonList { get; private set; } = new List<IMenuButton>();
        public int TabButtonIndex { get; set; } = 0;

        private ISprite menuBackground;
        private ICommand exitCommand;
        private ICommand MainMenuCommand;
        private IMenuState menuState;

        private int buttonWidth;
        private int buttonXPos;
        private Game1 game;

        public GameWinMenuState(Game1 game)
        {
            this.game = game;

            //I have no idea what is going on with the camera or what is going to be changed so this is not going to be drawn in the right location.
            menuBackground = MenuSpriteFactory.Instance.CreateSimpleBackgroundSprite(new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height));

            buttonXPos = game.Window.ClientBounds.Size.X / 2 - buttonWidth / 2;
            exitCommand = new QuitCommand(game);
            menuState = new StartMenuState(game);
            MainMenuCommand = new SetMenuStateCommand(menuState);

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
            SpriteFont font = MenuSpriteFactory.Instance.LargeDefaultFont;
            spriteBatch.DrawString(font, "You Win!", new Vector2(200, 150), Color.Blue);

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
            int buttonYPos = 250;
            int buttonYOffset = 50;

            SimpleMenuButton playButton = new SimpleMenuButton("Restart", new Vector2(buttonXPos, buttonYPos), new RestartCommand(game));
            ButtonList.Add(playButton);
            buttonYPos += buttonYOffset;

            SimpleMenuButton EndlessButton = new SimpleMenuButton("Quit", new Vector2(buttonXPos, buttonYPos), exitCommand);
            ButtonList.Add(EndlessButton);
            buttonYPos += buttonYOffset;

            SimpleMenuButton SettingsButton = new SimpleMenuButton("Main Menu", new Vector2(buttonXPos, buttonYPos), MainMenuCommand);
            ButtonList.Add(SettingsButton);

        }

    }
}

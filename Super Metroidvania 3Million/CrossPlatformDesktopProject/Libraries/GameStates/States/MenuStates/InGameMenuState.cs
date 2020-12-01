using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class InGameMenuState : AbstractMenuState
    {
        private ICommand exitCommand = new UnpauseGameCommand();
        private ISprite menuBackground;

        public InGameMenuState(Game1 game)
        {
            int menuXPos = 100;
            int menuYPos = 100;
            int menuWidth = 200;
            int menuHeight = 300;
            menuBackground = MenuSpriteFactory.Instance.CreateInGameMenuBackgroundSprite(new Rectangle(menuXPos, menuYPos, menuWidth, menuHeight));

            int buttonWidth = 60;
            int buttonHeight = 20;
            int buttonXPos = menuXPos + menuWidth / 2 - buttonWidth / 2;
            int buttonYPos = menuYPos + 80;

            Rectangle buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            ICommand buttonCommand = new UnpauseGameCommand();
            ButtonList.Add(new SimpleMenuButton("RESUME", buttonRectangle, buttonCommand));

            buttonYPos += buttonHeight * 2;
            buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            buttonCommand = new SetMenuStateCommand(new SettingsMenuState(game, this));
            ButtonList.Add(new SimpleMenuButton("SETTINGS", buttonRectangle, buttonCommand));

            buttonYPos += buttonHeight * 2;
            buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            buttonCommand = new RestartCommand(game);
            ButtonList.Add(new SimpleMenuButton("RESTART", buttonRectangle, buttonCommand));

            buttonYPos += buttonHeight * 2;
            buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            buttonCommand = new QuitCommand(game);
            ButtonList.Add(new SimpleMenuButton("QUIT", buttonRectangle, buttonCommand));

            ButtonList[0].IsSelected = true;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GameObjectContainer.Instance.Draw(spriteBatch); //draw the GOContainer first so that the menu then goes overtop.
            menuBackground.Draw(spriteBatch);
            foreach (IMenuButton button in ButtonList)
            {
                button.Draw(spriteBatch);
            }
        }

        //May move this is AbstractMenu and just override it if needed idk yet.
        public override void Update(GameTime gameTime)
        {

        }

        public override void ExitMenu()
        {
            exitCommand.Execute();
        }
    }
}

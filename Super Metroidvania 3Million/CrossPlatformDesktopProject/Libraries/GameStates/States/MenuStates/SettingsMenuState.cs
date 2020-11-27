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
        private ISprite menuBackground;
        private ICommand exitCommand;

        public SettingsMenuState(Game1 game, IMenuState backMenuState) {

            exitCommand = new SetMenuStateCommand(backMenuState);   

            int menuWidth = 800;
            int menuHeight = 480;
            menuBackground = MenuSpriteFactory.Instance.CreateSimpleBackgroundSprite(new Rectangle(0, 0, menuWidth, menuHeight));

            int buttonWidth = 60;
            int buttonHeight = 20;
            int buttonXPos = menuWidth / 2 - buttonWidth / 2;
            int buttonYPos = 80;

            Rectangle buttonRectangle = new Rectangle(buttonXPos, buttonYPos, buttonWidth, buttonHeight);
            ICommand buttonCommand = new SetMenuStateCommand(backMenuState);
            ButtonList.Add(new SimpleMenuButton(buttonRectangle, buttonCommand, "BACK"));

            buttonYPos += buttonHeight * 2;

            ButtonList[0].IsSelected = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            menuBackground.Draw(spriteBatch);
            foreach (IMenuButton button in ButtonList) {
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

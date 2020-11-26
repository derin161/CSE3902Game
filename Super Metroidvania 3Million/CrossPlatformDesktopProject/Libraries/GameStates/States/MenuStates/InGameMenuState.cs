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
    public class InGameMenuState : AbstractMenuState
    {
        private ICommand exitCommand = new UnpauseGameCommand();
        private ISprite menuBackground;

        public InGameMenuState(Game1 game) {
            menuBackground = MenuSpriteFactory.Instance.CreateInGameMenuBackground(new Rectangle(100, 100, 200, 300));
            int xPos = 150; //Need to make these good values and tweak them for each button.
            int yPos = 150;
            int width = 60;
            int height = 20;

            ButtonList.Add(new ResumeMenuButton(new Rectangle(xPos, yPos, width, height)));

            yPos += height + 20;
            ButtonList.Add(new SettingsMenuButton(new Rectangle(xPos, yPos, width, height)));

            yPos += height + 20;
            ButtonList.Add(new RestartMenuButton(new Rectangle(xPos, yPos, width, height), game));

            yPos += height + 20;
            ButtonList.Add(new QuitMenuButton(new Rectangle(xPos, yPos, width, height), game));

            ButtonList[0].IsSelected = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GameObjectContainer.Instance.Draw(spriteBatch); //draw the GOContainer first so that the menu then goes overtop.
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

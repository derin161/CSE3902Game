using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Command.PlayerCommands;
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace CrossPlatformDesktopProject.Libraries.GameStates
{
    //Author: Nyigel Spann
    public class QuitMenuButton : IMenuButton
    {
        public Rectangle Space { get; private set; }
        public bool IsSelected { get; set; } = false;

        private ISprite sprite;
        private ICommand quitCommand;

        public QuitMenuButton(Rectangle space, Game1 game) {
            Space = space;
            sprite = MenuSpriteFactory.Instance.CreateSimpleButtonSprite(this, "QUIT");
            quitCommand = new QuitCommand(game);
        }

        public void Left()
        {
            //Do nothing
        }

        public void Press()
        {
            quitCommand.Execute();
        }

        public void Right()
        {
            //Do nothing
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
        }
    }
}

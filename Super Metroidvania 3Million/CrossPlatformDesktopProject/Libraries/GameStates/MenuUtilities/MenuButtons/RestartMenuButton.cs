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
    public class RestartMenuButton : IMenuButton
    {
        public Rectangle Space { get; private set; }
        public bool IsSelected { get; set; } = false;

        private ISprite sprite;
        private ICommand restartCommand;

        public RestartMenuButton(Rectangle space, Game1 game) {
            Space = space;
            sprite = MenuSpriteFactory.Instance.CreateSimpleButtonSprite(this, "RESTART");
            restartCommand = new RestartCommand(game);
        }

        public void Left()
        {
            //Do nothing
        }

        public void Press()
        {
            restartCommand.Execute();
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

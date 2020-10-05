using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class Start : ICommand
    {
        private Game1 currentGame;
        public Start(Game1 game)
        {
            currentGame = game;
        }
        public void Execute()
        {
            currentGame.Exit();
        }
    }
}

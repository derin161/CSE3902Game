using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    class ToggleFullscreenCommand : ICommand
    {
        private Game1 game;
        public ToggleFullscreenCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.Fullscreen();
        }
    }
}


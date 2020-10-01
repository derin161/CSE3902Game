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
    //Author: Nyigel Spann
    class MoveLeft : ICommand
    {
        private PlayerSprite samus;
        private Game1 game;

        public MoveLeft(Game1 game, PlayerSprite player)
        {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (samus.walkLeftFrames == 7){
                samus.UpdateState(PlayerSprite.State.MoveLeft, -1, false);
            }else {
                samus.UpdateState(PlayerSprite.State.MoveLeft, samus.walkLeftFrames, false);
            }

        }
    }
}

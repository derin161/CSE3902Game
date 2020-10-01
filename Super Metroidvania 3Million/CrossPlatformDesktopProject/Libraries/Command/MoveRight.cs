using Microsoft.Xna;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Nyigel Spann
    class MoveRight : ICommand
    {
        private PlayerSprite samus;
        private Game1 game;

        public MoveRight(Game1 game, PlayerSprite player)
        {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (samus.walkRightFrames == 7){
                samus.UpdateState(PlayerSprite.State.MoveRight, -1, true);
            }else {
                samus.UpdateState(PlayerSprite.State.MoveRight, samus.walkRightFrames, true);
            }
        }
    }
}

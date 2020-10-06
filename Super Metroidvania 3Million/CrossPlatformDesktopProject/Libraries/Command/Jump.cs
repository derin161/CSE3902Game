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
    public class Jump : ICommand
    {
        private PlayerSprite samus;
        private Game1 game;

        public Jump(Game1 game, PlayerSprite player)
        {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!samus.jumpDisabled){
                if (samus.jumpFrames == 10){
                    samus.UpdateState(PlayerSprite.State.Jump, 0, samus.facingRight);
                }else {
                    samus.UpdateState(PlayerSprite.State.Jump, samus.jumpFrames, samus.facingRight);
                }
            }

        }
    }
}

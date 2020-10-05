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
            if (samus.currentState == PlayerSprite.State.Jump){
                samus.Location = new Vector2(samus.Location.X - samus.xIncrease, samus.Location.Y);
            }else if (samus.moveLeftFrames == 7){
                samus.UpdateState(PlayerSprite.State.MoveLeft, -1, false);
            }else {
                samus.UpdateState(PlayerSprite.State.MoveLeft, samus.moveLeftFrames, false);
            }

        }
    }
}

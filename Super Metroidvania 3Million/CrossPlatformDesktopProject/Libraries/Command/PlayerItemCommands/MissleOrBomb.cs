using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.SFactory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class MissleOrBomb : ICommand
    {
        private ICommand missle;
        private ICommand bomb;
        private PlayerSprite samus;

        //This should probably be changed at some point, but this class essentially just redirects to ShootMissleRocket or DropBomb depending on the player's state.
        public MissleOrBomb(Game1 game, PlayerSprite player) {
            missle = new ShootMissileRocket(game, player);
            bomb = new DropBomb(game, player);
            samus = player;
        }
        public void Execute()
        {
            switch (samus.currentState)
            {
                case PlayerSprite.State.Crouch: //List all the states where Samus is allowed to drop bombs
                case PlayerSprite.State.Jump:
                    bomb.Execute();
                    break;
                default: //Otherwise she shoots a rocket
                    missle.Execute();
                    break;
            }

        }
    }
}

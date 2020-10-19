using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using System.Collections.Generic;
using System.Linq;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class MissileOrBomb : ICommand
    {
        private ICommand missile;
        private ICommand bomb;
        private PlayerSprite samus;
        private List<PlayerSprite.State> bombStates = new List<PlayerSprite.State> { PlayerSprite.State.Crouch, PlayerSprite.State.Jump };
        private List<PlayerSprite.State> missileStates = new List<PlayerSprite.State> { PlayerSprite.State.MoveLeft, PlayerSprite.State.MoveRight, PlayerSprite.State.Idle };

        //This should probably be changed at some point, but this class essentially just redirects to ShootMissleRocket or DropBomb depending on the player's state.
        public MissileOrBomb(Game1 game, PlayerSprite player) {
            missile = new ShootMissileRocket(game, player);
            bomb = new DropBomb(game, player);
            samus = player;
        }
        public void Execute()
        {

            if (bombStates.Contains(samus.currentState)) {
                bomb.Execute();
            } else if (missileStates.Contains(samus.currentState)) {
                missile.Execute();
            }

        }
    }
}

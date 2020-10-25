using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class MissileOrBombCommand : ICommand
    {
        private ICommand missile;
        private ICommand bomb;
        private Player samus;
        private List<Player.State> bombStates = new List<Player.State> { Player.State.Crouch, Player.State.Jump };
        private List<Player.State> missileStates = new List<Player.State> { Player.State.MoveLeft, Player.State.MoveRight, Player.State.Idle };

        //This should probably be changed at some point, but this class essentially just redirects to ShootMissleRocket or DropBomb depending on the player's state.
        public MissileOrBombCommand(Game1 game, Player player) {
            missile = new ShootMissileRocketCommand(game, player);
            bomb = new DropBombCommand(game, player);
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

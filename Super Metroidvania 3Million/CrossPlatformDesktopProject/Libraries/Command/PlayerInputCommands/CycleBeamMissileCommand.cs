using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class CycleBeamMissileCommand : ICommand
    {
        private IPlayer player;

        //This should probably be changed at some point, but this class essentially just redirects to ShootMissleRocket or DropBomb depending on the player's state.
        public CycleBeamMissileCommand(IPlayer player) {
            /*Although we could get the player from the GOContainer, take a player into the constructor for better future co-op support. */
            this.player = player;
        }
        public void Execute()
        {
            player.CycleBeamMissile();
        }
    }
}

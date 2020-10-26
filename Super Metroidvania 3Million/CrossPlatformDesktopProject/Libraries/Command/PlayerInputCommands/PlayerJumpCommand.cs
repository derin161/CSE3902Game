using CrossPlatformDesktopProject.Libraries.Sprite.Player;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Nyigel Spann
    public class PlayerJumpCommand : ICommand
    {
        private IPlayer player;

        public PlayerJumpCommand(IPlayer player)
        {
            /*Although we could get the player from the GOContainer, take a player into the constructor for better future co-op support. */
            this.player = player;
        }
        public void Execute()
        {
            /* This logic needs to be moved into the player class
            if (!samus.jumpDisabled){
                if (samus.jumpFrames == 10){
                    samus.UpdateState(Player.State.Jump, 0, samus.facingRight);
                }else {
                    samus.UpdateState(Player.State.Jump, samus.jumpFrames, samus.facingRight);
                }
            }*/

        }
    }
}

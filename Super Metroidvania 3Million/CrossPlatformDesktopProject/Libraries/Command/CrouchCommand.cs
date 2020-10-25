using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    public class CrouchCommand : ICommand
    {
        private Player samus;
        private Game1 game;

        public CrouchCommand(Game1 game, Player player)
        {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!samus.crouchDisabled){
                if (samus.crouchFrames == 4){
                    samus.UpdateState(Player.State.Crouch, -1, samus.facingRight);
                }else {
                    samus.UpdateState(Player.State.Crouch, samus.crouchFrames, samus.facingRight);
                }
            }

        }
    }
}

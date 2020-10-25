using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    public class PlayerJumpCommand : ICommand
    {
        private Player samus;
        private Game1 game;

        public PlayerJumpCommand(Game1 game, Player player)
        {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!samus.jumpDisabled){
                if (samus.jumpFrames == 10){
                    samus.UpdateState(Player.State.Jump, 0, samus.facingRight);
                }else {
                    samus.UpdateState(Player.State.Jump, samus.jumpFrames, samus.facingRight);
                }
            }

        }
    }
}

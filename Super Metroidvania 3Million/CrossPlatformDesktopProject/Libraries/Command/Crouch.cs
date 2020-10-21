using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    public class Crouch : ICommand
    {
        private PlayerSprite samus;
        private Game1 game;

        public Crouch(Game1 game, PlayerSprite player)
        {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!samus.crouchDisabled){
                if (samus.crouchFrames == 4){
                    samus.UpdateState(PlayerSprite.State.Crouch, -1, samus.facingRight);
                }else {
                    samus.UpdateState(PlayerSprite.State.Crouch, samus.crouchFrames, samus.facingRight);
                }
            }

        }
    }
}

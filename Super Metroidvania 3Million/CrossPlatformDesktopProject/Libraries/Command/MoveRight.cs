using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class MoveRight : ICommand
    {
        private PlayerSprite samus;
        private Game1 game;

        public MoveRight(Game1 game, PlayerSprite player)
        {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!samus.moveDisabled){
                if (samus.currentState == PlayerSprite.State.Jump){
                    samus.Location = new Vector2(samus.Location.X + 20, samus.Location.Y);
                }else if (samus.moveRightFrames == 7){
                    samus.UpdateState(PlayerSprite.State.MoveRight, -1, true);
                }else {
                    samus.UpdateState(PlayerSprite.State.MoveRight, samus.moveRightFrames, true);
                }
            }
        }
    }
}

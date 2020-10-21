using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
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
            if (!samus.moveDisabled){
                if (samus.currentState == PlayerSprite.State.Jump){
                    samus.Location = new Vector2(samus.Location.X - 20, samus.Location.Y);
                }else if (samus.moveLeftFrames == 7){
                    samus.UpdateState(PlayerSprite.State.MoveLeft, -1, false);
                }else {
                    samus.UpdateState(PlayerSprite.State.MoveLeft, samus.moveLeftFrames, false);
                }
            }

        }
    }
}

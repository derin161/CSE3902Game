using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class PlayeroveRightCommand : ICommand
    {
        private Player samus;
        private Game1 game;

        public PlayeroveRightCommand(Game1 game, Player player)
        {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!samus.moveDisabled){
                if (samus.currentState == Player.State.Jump){
                    samus.Location = new Vector2(samus.Location.X + 20, samus.Location.Y);
                }else if (samus.moveRightFrames == 7){
                    samus.UpdateState(Player.State.MoveRight, -1, true);
                }else {
                    samus.UpdateState(Player.State.MoveRight, samus.moveRightFrames, true);
                }
            }
        }
    }
}

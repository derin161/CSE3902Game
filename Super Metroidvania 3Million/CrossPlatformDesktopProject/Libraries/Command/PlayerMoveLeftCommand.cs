using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class PlayerMoveLeftCommand : ICommand
    {
        private Player samus;
        private Game1 game;

        public PlayerMoveLeftCommand(Game1 game, Player player)
        {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!samus.moveDisabled){
                if (samus.currentState == Player.State.Jump){
                    samus.Location = new Vector2(samus.Location.X - 20, samus.Location.Y);
                }else if (samus.moveLeftFrames == 7){
                    samus.UpdateState(Player.State.MoveLeft, -1, false);
                }else {
                    samus.UpdateState(Player.State.MoveLeft, samus.moveLeftFrames, false);
                }
            }

        }
    }
}

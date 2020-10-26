using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Nyigel Spann
    class PlayerMoveRightCommand : ICommand
    {
        private IPlayer player;

        public PlayerMoveRightCommand(IPlayer player)
        {
            /*Although we could get the player from the GOContainer, take a player into the constructor for better future co-op support. */
            this.player = player;
        }
        public void Execute()
        {
            player.MoveRight();
            /* This logic needs to be moved into the player class
            if (!samus.moveDisabled){
                if (samus.currentState == Player.State.Jump){
                    samus.Location = new Vector2(samus.Location.X + 20, samus.Location.Y);
                }else if (samus.moveRightFrames == 7){
                    samus.UpdateState(Player.State.MoveRight, -1, true);
                }else {
                    samus.UpdateState(Player.State.MoveRight, samus.moveRightFrames, true);
                }
            }*/
        }
    }
}

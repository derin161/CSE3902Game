using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Nyigel Spann
    class PlayerMoveLeftCommand : ICommand
    {
        private IPlayer player;

        public PlayerMoveLeftCommand(IPlayer player)
        {
            /*Although we could get the player from the GOContainer, take a player into the constructor for better future co-op support. */
            this.player = player; 
        }
        public void Execute()
        {
            player.MoveLeft();
            /* This logic needs to moved into the player.
            if (!samus.moveDisabled){
                if (samus.currentState == Player.State.Jump){
                    samus.Location = new Vector2(samus.Location.X - 20, samus.Location.Y);
                }else if (samus.moveLeftFrames == 7){
                    samus.UpdateState(Player.State.MoveLeft, -1, false);
                }else {
                    samus.UpdateState(Player.State.MoveLeft, samus.moveLeftFrames, false);
                }
            }*/

        }
    }
}

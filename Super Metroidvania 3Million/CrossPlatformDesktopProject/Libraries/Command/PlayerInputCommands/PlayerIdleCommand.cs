using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Nyigel Spann
    class PlayerIdleCommand : ICommand
    {
        private IPlayer player;

        public PlayerIdleCommand(IPlayer player)
        {
            /*Although we could get the player from the GOContainer, take a player into the constructor for better future co-op support. */
            this.player = player; 
        }
        public void Execute()
        {
            player.Idle();
        }
    }
}

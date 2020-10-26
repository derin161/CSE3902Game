using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class PlayerDamageCommand : ICommand
    {
        private IPlayer player;

        public PlayerDamageCommand(Game1 game, IPlayer player) {
            this.player = player;
        }
        public void Execute()
        {
            /* Not really sure how we're going to get the actual damage values we need right here... -Nyigel */
            int damage = 10;
            player.TakeDamage(damage);
        }
    }
}

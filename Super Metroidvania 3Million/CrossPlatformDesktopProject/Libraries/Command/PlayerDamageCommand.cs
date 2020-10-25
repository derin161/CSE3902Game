using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class PlayerDamageCommand : ICommand
    {
        private Player samus;
        private Game1 game;

        public PlayerDamageCommand(Game1 game, Player player) {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!samus.damageDisabled){
                samus.UpdateHealth(samus.currentHealth - 10, samus.maxHealth);
                samus.HealthBar(samus.currentHealth - 10, samus.maxHealth);
                samus.UpdateHealthState();

                samus.UpdateState(Player.State.Damage, samus.damageFrames++, samus.facingRight);
            }

        }
    }
}

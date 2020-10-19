using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class Damage : ICommand
    {
        private PlayerSprite samus;
        private Game1 game;

        public Damage(Game1 game, PlayerSprite player) {
            samus = player;
            this.game = game;
        }
        public void Execute()
        {
            if (!samus.damageDisabled){
                samus.UpdateHealth(samus.currentHealth - 10, samus.maxHealth);
                samus.HealthBar(samus.currentHealth - 10, samus.maxHealth);
                samus.UpdateHealthState();

                samus.UpdateState(PlayerSprite.State.Damage, samus.damageFrames++, samus.facingRight);
            }

        }
    }
}

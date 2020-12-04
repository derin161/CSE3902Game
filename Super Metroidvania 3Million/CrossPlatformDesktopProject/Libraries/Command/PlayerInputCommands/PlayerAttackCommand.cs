using SuperMetroidvania5Million.Libraries.Audio;
using SuperMetroidvania5Million.Libraries.Sprite.Player;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    class PlayerAttackCommand : IDisableableCommand
    {
        public bool Disabled { get; set; } = false;
        private IPlayer player;


        public PlayerAttackCommand(IPlayer player)
        {
            /*Although we could get the player from the GOContainer, take a player into the constructor for better future co-op support. */
            this.player = player;
        }

        public void Execute()
        {
            if (!Disabled)
            {
                SoundManager.Instance.Projectiles.PowerBeamFireSound.PlaySound();
                player.Attack();
                Disabled = true;
            }
        }
    }
}

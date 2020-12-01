using SuperMetroidvania5Million.Libraries.Sprite.Player;
using SuperMetroidvania5Million.Libraries.Sprite.Projectiles;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    class ProjectileDamagePlayerCommand : ICommand
    {
        private IPlayer player;
        private IProjectile projectile;
        public ProjectileDamagePlayerCommand(IPlayer player, IProjectile projectile)
        {
            this.player = player;
            this.projectile = projectile;
        }
        public void Execute()
        {
            player.TakeDamage(projectile.GetDamage());
        }
    }
}

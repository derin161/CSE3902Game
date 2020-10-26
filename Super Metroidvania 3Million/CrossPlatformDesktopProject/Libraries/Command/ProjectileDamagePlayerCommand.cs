using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class ProjectileDamagePlayerCommand : ICommand
    {
        private IPlayer player;
        private IProjectile projectile;
        public ProjectileDamagePlayerCommand(IPlayer player, IProjectile projectile) {
            this.player = player;
            this.projectile = projectile;
        }
        public void Execute()
        {
            player.TakeDamage(projectile.GetDamage());
        }
    }
}

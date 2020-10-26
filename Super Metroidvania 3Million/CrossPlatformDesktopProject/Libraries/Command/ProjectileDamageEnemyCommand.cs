using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class ProjectileDamageEnemyCommand : ICommand
    {
        private IEnemy enemy;
        private IProjectile projectile;
        public ProjectileDamageEnemyCommand(IProjectile projectile, IEnemy enemy) {
            this.enemy = enemy;
            this.projectile = projectile;
        }
        public void Execute()
        {
            enemy.TakeDamage(projectile.GetDamage());
        }
    }
}

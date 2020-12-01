using SuperMetroidvania5Million.Libraries.Sprite.EnemySprites;
using SuperMetroidvania5Million.Libraries.Sprite.Projectiles;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    class ProjectileDamageEnemyCommand : ICommand
    {
        private IEnemy enemy;
        private IProjectile projectile;
        public ProjectileDamageEnemyCommand(IProjectile projectile, IEnemy enemy)
        {
            this.enemy = enemy;
            this.projectile = projectile;
        }
        public void Execute()
        {
            enemy.TakeDamage(projectile.GetDamage());
        }
    }
}

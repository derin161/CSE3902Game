using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Libraries.Collision
{
    class CollisionHandler
    {
        public CollisionHandler()
        {

        }

        public void PlayerEnemyCollision(IPlayer player, IEnemy enemy)
        {
            new PlayerEnemyCollision().HandleCollision(player, enemy);
        }

        public void PlayerBlockCollision(IPlayer player, IBlock block, Rectangle collisionZone)
        {
            new PlayerBlockCollision().HandleCollision(player, block, collisionZone);
        }

        public void PlayerProjectileCollision(IPlayer player, IProjectile projectile)
        {
            new PlayerProjectileCollision().HandleCollision(player, projectile);
        }

        public void EnemyBlockCollision(IEnemy enemy, IBlock block, Rectangle collisionZone)
        {
            new EnemyBlockCollision().HandleCollision(enemy, block, collisionZone);
        }

        public void ProjectileBlockCollision(IProjectile projectile, IBlock block)
        {
            new ProjectileBlockCollision().HandleCollision(projectile, block);
        }

        public void ProjectileEnemyCollision(IProjectile projectile, IEnemy enemy)
        {
            new ProjectileEnemyCollision().HandleCollision(projectile, enemy);
        }

        public void PlayerItemCollision(IPlayer player, IItem item)
        {
            new PlayerItemCollision().HandleCollision(player, item);
        }
    }
}

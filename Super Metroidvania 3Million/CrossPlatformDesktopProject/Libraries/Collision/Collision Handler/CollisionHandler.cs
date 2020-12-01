using SuperMetroidvania5Million.Libraries.Sprite.Player;
using SuperMetroidvania5Million.Libraries.Sprite.Projectiles;
using SuperMetroidvania5Million.Libraries.Sprite.Items;
using SuperMetroidvania5Million.Libraries.Sprite.EnemySprites;
using SuperMetroidvania5Million.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;

namespace SuperMetroidvania5Million.Libraries.Collision
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

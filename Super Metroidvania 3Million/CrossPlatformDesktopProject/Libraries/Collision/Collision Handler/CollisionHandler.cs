using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.Items;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.Libraries.Command;
using System.Collections;
using CrossPlatformDesktopProject.Libraries.CSV;

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
            //Kill the projectile
            projectile.Kill();
        }

        public void ProjectileEnemyCollision(IProjectile projectile, IEnemy enemy)
        {
            //Cast so we can then determine is it's an ice beam or not, casting will succeed if the first statement is true.
            if (projectile is PowerBeam && ((PowerBeam)projectile).IsIceBeam)
            {
                new EnemyFreezeCommand(enemy).Execute();
            }
            if (!(projectile is KraidHorn) && !(projectile is KraidMissile))
            {
                new ProjectileDamageEnemyCommand(projectile, enemy).Execute();
                projectile.Kill();
            }
        }

        public void PlayerItemCollision(IPlayer player, IItem item)
        {
            new PlayerGiveItemCommand(item, player).Execute();
            item.Kill();
        }
    }
}

using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
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

        public void PlayerEnemyCollision(IPlayer player, IGameObject enemy)
        {
            //Do amount of damage spcified by enemy to player
        }

        public void PlayerBlockCollision(IPlayer player, IBlock block, Rectangle collisionZone)
        {
            //Determine the direction that the player came from and push the player back out of the block
        }

        public void PlayerProjectileCollision(IPlayer player, IProjectile projectile)
        {
            //Do damage specifiied by the projectile to the player
            //This method should only be called for Kraid's projectiles, no other enemies have any
        }

        public void EnemyBlockCollision(IEnemy enemy, IBlock block, Rectangle collisionZone)
        {
            //Same as player block collisions
            //Determine direction that enemy came from and push them back out of the block
        }

        public void ProjectileBlockCollision(IProjectile projectile, IBlock block)
        {
            //Kill the projectile
        }

        public void ProjectileEnemyCollision(IProjectile projectile, IEnemy enemy)
        {
            //Do amount of damage to enemies specified by the projectile 
        }

        public void PlayerItemCollision(IPlayer player, IItem item)
        {
            //Do amount of damage to enemies specified by the projectile 
        }
    }
}

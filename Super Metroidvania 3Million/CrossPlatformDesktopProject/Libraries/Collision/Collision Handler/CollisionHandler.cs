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


            //player.TakeDamage(enemy.GetDamage());
        }

        public void PlayerBlockCollision(IPlayer player, IBlock block, Rectangle collisionZone)
        {
            //Determine the direction that the player came from and push the player back out of the block
            //Use collisionZone to determine LEFT/RIGHT or TOP/BOTTOM collision.
            //If collisionZone is more tall than wide, then it's TOP/BOTTOM, else, LEFT/RIGHT.
        }

        public void PlayerProjectileCollision(IPlayer player, IProjectile projectile)
        {
            //Do damage specifiied by the projectile to the player
            //This method should only be called for Kraid's projectiles, no other enemies have any


            //player.TakeDamage(projectile.GetDamage());
        }

        public void EnemyBlockCollision(IEnemy enemy, IBlock block, Rectangle collisionZone)
        {
            //Same as player block collisions
            //Player should become temporarily invulnerable and blink. Logic likely in Player class accessed through TakeDamage command.
            //Use collisionZone to determine LEFT/RIGHT or TOP/BOTTOM collision.
            //If collisionZone is more tall than wide, then it's TOP/BOTTOM, else, LEFT/RIGHT.
        }

        public void ProjectileBlockCollision(IProjectile projectile, IBlock block)
        {
            //Kill the projectile


            //projectile.Kill();
        }

        public void ProjectileEnemyCollision(IProjectile projectile, IEnemy enemy)
        {
            //Do amount of damage to enemies specified by the projectile
            //kill the projectile


            //enemy.TakeDamage(projectile.GetDamage());
            //projectile.Kill();
        }

        public void PlayerItemCollision(IPlayer player, IItem item)
        {
            //Give player the corresponding upgrade or give them more energy or missiles


        }
    }
}

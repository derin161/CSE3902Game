using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;

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

        public void PlayerBlockCollision(IPlayer player, IGameObject block)
        {
            //Determine the direction that the player came from and push the player back out of the block
        }

        public void PlayerProjectileCollision(IPlayer player, IGameObject projectile)
        {
            //Do damage specifiied by the projectile to the player
            //This method should only be called for Kraid's projectiles, no other enemies have any
        }

        public void EnemyBlockCollision(IGameObject enemy, IGameObject block)
        {
            //Same as player block collisions
            //Determine direction that enemy came from and push them back out of the block
        }

        public void ProjectileBlockCollision(IGameObject projectile, IGameObject block)
        {
            //Kill the projectile
        }

        public void ProjectileEnemyCollision(IGameObject projectile, IGameObject enemy)
        {
            //Do amount of damage to enemies specified by the projectile 
        }

        public void PlayerItemCollision(IPlayer player, IGameObject item)
        {
            //Do amount of damage to enemies specified by the projectile 
        }
    }
}

using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.Blocks;

namespace CrossPlatformDesktopProject.Libraries.Collision
{
    class ProjectileBlockCollision
    {
        public ProjectileBlockCollision()
        {

        }

        public void HandleCollision(IProjectile projectile, IBlock block)
        {
            projectile.Kill();
        }

    }
}
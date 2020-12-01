using SuperMetroidvania5Million.Libraries.Sprite.Projectiles;
using SuperMetroidvania5Million.Libraries.Sprite.Blocks;

namespace SuperMetroidvania5Million.Libraries.Collision
{
    //Author: Nyigel Spann and Will Floyd
    public class ProjectileBlockCollision
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
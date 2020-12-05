using SuperMetroidvania5Million.Libraries.Sprite.Projectiles;
using SuperMetroidvania5Million.Libraries.Sprite.Blocks;
using SuperMetroidvania5Million.Libraries.Command;

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
            if (!(projectile is KraidHorn) && !(projectile is KraidMissile))
            {
                if (block is IDoorBlock)
                {
                    new ProjectileDamageDoorBlockCommand(projectile, block).Execute();
                }

            }

            projectile.Kill();
        }

    }
}
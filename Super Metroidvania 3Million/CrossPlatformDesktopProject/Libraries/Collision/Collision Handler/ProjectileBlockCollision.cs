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
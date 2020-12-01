using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Command;
using CrossPlatformDesktopProject.Libraries.Audio;

namespace CrossPlatformDesktopProject.Libraries.Collision
{
    //Author: Nyigel Spann and Will Floyd
    public class ProjectileEnemyCollision
    {
        public ProjectileEnemyCollision()
        {

        }

        public void HandleCollision(IProjectile projectile, IEnemy enemy)
        {
            //Cast so we can then determine is it's an ice beam or not, casting will succeed if the first statement is true.
            if (projectile is PowerBeam && ((PowerBeam)projectile).IsIceBeam)
            {
                new EnemyFreezeCommand(enemy).Execute();
            }
            if (!(projectile is KraidHorn) && !(projectile is KraidMissile))
            {
                new ProjectileDamageEnemyCommand(projectile, enemy).Execute();
                SoundManager.Instance.Projectiles.PowerBeamCollideSound.PlaySound();
                projectile.Kill();
            }
        }

    }
}
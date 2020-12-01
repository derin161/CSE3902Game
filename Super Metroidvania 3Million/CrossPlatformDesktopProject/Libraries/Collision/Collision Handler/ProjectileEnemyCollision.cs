using SuperMetroidvania5Million.Libraries.Sprite.Projectiles;
using SuperMetroidvania5Million.Libraries.Sprite.EnemySprites;
using SuperMetroidvania5Million.Libraries.Command;
using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Collision
{
    class ProjectileEnemyCollision
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
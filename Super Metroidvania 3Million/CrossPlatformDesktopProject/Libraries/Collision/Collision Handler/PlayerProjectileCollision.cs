using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.Projectiles;
using CrossPlatformDesktopProject.Libraries.Command;

namespace CrossPlatformDesktopProject.Libraries.Collision
{
    //Author: Nyigel Spann and Will Floyd
    public class PlayerProjectileCollision
    {
        public PlayerProjectileCollision()
        {

        }

        public void HandleCollision(IPlayer player, IProjectile projectile)
        {
            if (projectile is KraidHorn || projectile is KraidMissile)
            { //Only kraid projectiles deal damage to the player.
                new ProjectileDamagePlayerCommand(player, projectile).Execute();
            }
        }

    }

}
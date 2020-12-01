using SuperMetroidvania5Million.Libraries.Sprite.Player;
using SuperMetroidvania5Million.Libraries.Sprite.Projectiles;
using SuperMetroidvania5Million.Libraries.Command;

namespace SuperMetroidvania5Million.Libraries.Collision
{
    class PlayerProjectileCollision
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
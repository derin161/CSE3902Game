using CrossPlatformDesktopProject.Libraries.Sprite.Player;
using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Command;

namespace CrossPlatformDesktopProject.Libraries.Collision
{
    class PlayerEnemyCollision
    {
        public PlayerEnemyCollision()
        {

        }

        public void HandleCollision(IPlayer player, IEnemy enemy)
        {
            new EnemyDamagePlayerCommand(player, enemy).Execute();
        }

    }
}
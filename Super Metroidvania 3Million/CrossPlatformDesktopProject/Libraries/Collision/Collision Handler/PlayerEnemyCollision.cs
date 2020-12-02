using SuperMetroidvania5Million.Libraries.Sprite.Player;
using SuperMetroidvania5Million.Libraries.Sprite.EnemySprites;
using SuperMetroidvania5Million.Libraries.Command;

namespace SuperMetroidvania5Million.Libraries.Collision
{
    //Author: Nyigel Spann and Will Floyd
    public class PlayerEnemyCollision
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
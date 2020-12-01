using SuperMetroidvania5Million.Libraries.Sprite.EnemySprites;
using SuperMetroidvania5Million.Libraries.Sprite.Player;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    class EnemyDamagePlayerCommand : ICommand
    {
        private IPlayer player;
        private IEnemy enemy;
        public EnemyDamagePlayerCommand(IPlayer player, IEnemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }
        public void Execute()
        {
            //Should be a timer to avoid getting damaged multiple times by one collision, player should blink while timer is active
            player.TakeDamage(enemy.GetDamage());
        }
    }
}

using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.Player;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class EnemyDamagePlayerCommand : ICommand
    {
        private IPlayer player;
        private IEnemy enemy;
        private int damage;
        public EnemyDamagePlayerCommand(IPlayer player, IEnemy enemy) {
            this.player = player;
            this.enemy = enemy;
            damage = 10;
        }
        public void Execute()
        {
            player.TakeDamage(damage);
        }
    }
}

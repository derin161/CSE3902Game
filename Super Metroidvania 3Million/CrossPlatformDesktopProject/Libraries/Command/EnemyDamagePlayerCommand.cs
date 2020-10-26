using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;
using CrossPlatformDesktopProject.Libraries.Sprite.PlayerSprite;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
{
    //Author: Shyamal Shah
    class EnemyDamagePlayerCommand : ICommand
    {
        private IPlayer player;
        private IEnemy enemy;
        public EnemyDamagePlayerCommand(Game1 game, IPlayer player, IEnemy enemy) {
            this.player = player;
            this.enemy = enemy;
        }
        public void Execute()
        {
            player.TakeDamage(enemy.GetDamage());
        }
    }
}

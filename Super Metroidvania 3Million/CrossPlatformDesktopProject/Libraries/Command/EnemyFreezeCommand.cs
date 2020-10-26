using CrossPlatformDesktopProject.Libraries.Sprite.EnemySprites;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class EnemyFreezeCommand : ICommand
    {
        private IEnemy enemy;
        public EnemyFreezeCommand(IEnemy enemy) {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.Freeze();
        }
    }
}

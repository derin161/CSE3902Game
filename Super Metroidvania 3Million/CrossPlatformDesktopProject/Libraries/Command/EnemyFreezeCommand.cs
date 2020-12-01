using SuperMetroidvania5Million.Libraries.Sprite.EnemySprites;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    class EnemyFreezeCommand : ICommand
    {
        private IEnemy enemy;
        public EnemyFreezeCommand(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.Freeze();
        }
    }
}

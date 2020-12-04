using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.CSV;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Tristan Roman
    class DungeonBCommand : ICommand
    {
        Game1 game;
        public DungeonBCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            LevelStatePattern.Instance.InitializeB(game);
            GameStateMachine.Instance.Play();
        }
    }
}

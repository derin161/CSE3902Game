using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.CSV;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Tristan Roman
    class PlayCommand : ICommand
    {
        Game1 game;
        public PlayCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            LevelStatePattern.Instance.Initialize(game);
            GameStateMachine.Instance.Play();
        }
    }
}

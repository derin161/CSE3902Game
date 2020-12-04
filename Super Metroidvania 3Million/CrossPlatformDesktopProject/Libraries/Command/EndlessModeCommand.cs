using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.CSV;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Shyamal Shah
    class EndlessModeCommand : ICommand
    {
        Game1 game;
        public EndlessModeCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //Set room to an empty room with all powerups
            LevelStatePattern.Instance.InitializeEndlessMode(game);
            GameStateMachine.Instance.Play();
        }
    }
}

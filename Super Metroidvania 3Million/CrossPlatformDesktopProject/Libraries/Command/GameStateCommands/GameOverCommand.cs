using SuperMetroidvania5Million.Libraries.Container;

namespace SuperMetroidvania5Million.Libraries.Command
{
    class GameOverCommand : ICommand
    {
        public GameOverCommand()
        {

        }
        public void Execute()
        {
            GameStateMachine.Instance.GameOver();
        }
    }
}

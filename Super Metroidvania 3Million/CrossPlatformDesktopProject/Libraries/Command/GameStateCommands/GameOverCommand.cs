using CrossPlatformDesktopProject.Libraries.Container;

namespace CrossPlatformDesktopProject.Libraries.Command.PlayerCommands
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

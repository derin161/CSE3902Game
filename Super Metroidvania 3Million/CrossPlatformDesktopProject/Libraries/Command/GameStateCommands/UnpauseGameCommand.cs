using CrossPlatformDesktopProject.Libraries.Container;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Shyamal Shah
    class UnpauseGameCommand : ICommand
    {
        public UnpauseGameCommand()
        {

        }
        public void Execute()
        {
            GameStateMachine.Instance.Play();
        }
    }
}

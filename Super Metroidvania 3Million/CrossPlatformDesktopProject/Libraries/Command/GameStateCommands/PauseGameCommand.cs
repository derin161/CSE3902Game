using SuperMetroidvania5Million.Libraries.Container;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Shyamal Shah
    class PauseGameCommand : ICommand
    {
        public PauseGameCommand()
        {

        }
        public void Execute()
        {
            GameStateMachine.Instance.Pause();
        }
    }
}

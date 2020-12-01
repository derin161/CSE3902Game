using SuperMetroidvania5Million.Libraries.Container;

namespace SuperMetroidvania5Million.Libraries.Command
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

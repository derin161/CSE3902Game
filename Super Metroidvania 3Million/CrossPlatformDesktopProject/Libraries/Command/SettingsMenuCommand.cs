using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.GameStates;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    public class SettingsMenuCommand : ICommand
    {
        private IMenuState state;
        public SettingsMenuCommand(IMenuState menuState)
        {
            state = menuState;
        }
        public void Execute()
        {
            GameStateMachine.Instance.MenuState(state);
        }
    }
}

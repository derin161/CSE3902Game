
using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.GameStates;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    public class SetMenuStateCommand : ICommand
    {
        private IMenuState menu;

        public SetMenuStateCommand(IMenuState menuState)
        {
            menu = menuState;
        }
        public void Execute()
        {
            GameStateMachine.Instance.MenuState(menu);
        }
    }
}

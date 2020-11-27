
using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.GameStates;

namespace CrossPlatformDesktopProject.Libraries.Command
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

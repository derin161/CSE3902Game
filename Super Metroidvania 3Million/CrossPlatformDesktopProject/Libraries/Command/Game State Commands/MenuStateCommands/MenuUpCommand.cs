using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.GameStates;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class MenuUpCommand : ICommand
    {
        private IMenuState menu;
        public MenuUpCommand(IMenuState menuState)
        {
            menu = menuState;
        }
        public void Execute()
        {
            menu.Up();
        }
    }
}

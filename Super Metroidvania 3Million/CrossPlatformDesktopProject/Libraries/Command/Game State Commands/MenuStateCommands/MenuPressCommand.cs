using CrossPlatformDesktopProject.Libraries.Container;
using CrossPlatformDesktopProject.Libraries.GameStates;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    class MenuPressCommand : ICommand
    {
        private IMenuState menu;
        public MenuPressCommand(IMenuState menuState)
        {
            menu = menuState;
        }
        public void Execute()
        {
            menu.PressButton();
        }
    }
}

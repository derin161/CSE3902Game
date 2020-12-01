using CrossPlatformDesktopProject.Libraries.GameStates;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class MenuLeftCommand : ICommand
    {
        private IMenuState menu;
        public MenuLeftCommand(IMenuState menuState)
        {
            menu = menuState;
        }
        public void Execute()
        {
            menu.Left();
        }
    }
}

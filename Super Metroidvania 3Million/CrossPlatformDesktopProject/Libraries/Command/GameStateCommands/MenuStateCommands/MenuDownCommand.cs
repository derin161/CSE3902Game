using CrossPlatformDesktopProject.Libraries.GameStates;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class MenuDownCommand : ICommand
    {
        private IMenuState menu;
        public MenuDownCommand(IMenuState menuState)
        {
            menu = menuState;
        }
        public void Execute()
        {
            menu.Down();
        }
    }
}

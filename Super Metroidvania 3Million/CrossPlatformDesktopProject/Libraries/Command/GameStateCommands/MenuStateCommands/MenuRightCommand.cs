using CrossPlatformDesktopProject.Libraries.GameStates;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class MenuRightCommand : ICommand
    {
        private IMenuState menu;
        public MenuRightCommand(IMenuState menuState)
        {
            menu = menuState;
        }
        public void Execute()
        {
            menu.Right();
        }
    }
}

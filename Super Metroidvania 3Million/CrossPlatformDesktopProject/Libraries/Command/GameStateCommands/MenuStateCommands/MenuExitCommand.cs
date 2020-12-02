using SuperMetroidvania5Million.Libraries.GameStates;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    public class MenuExitCommand : ICommand
    {
        private IMenuState menu;
        public MenuExitCommand(IMenuState menuState)
        {
            menu = menuState;
        }
        public void Execute()
        {
            menu.ExitMenu();
        }
    }
}

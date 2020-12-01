using SuperMetroidvania5Million.Libraries.GameStates;

namespace SuperMetroidvania5Million.Libraries.Command
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

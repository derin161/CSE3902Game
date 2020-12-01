using SuperMetroidvania5Million.Libraries.GameStates;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    public class MenuPressCommand : ICommand
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

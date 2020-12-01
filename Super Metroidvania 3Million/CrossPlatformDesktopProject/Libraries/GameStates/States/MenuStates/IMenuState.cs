using SuperMetroidvania5Million.Libraries.Container;

namespace SuperMetroidvania5Million.Libraries.GameStates
{
    //Author: Nyigel Spann
    public interface IMenuState : IGameState
    {
        public void ExitMenu();
        public void Up();
        public void Down();
        public void Left();
        public void Right();
        public void PressButton();
    }
}

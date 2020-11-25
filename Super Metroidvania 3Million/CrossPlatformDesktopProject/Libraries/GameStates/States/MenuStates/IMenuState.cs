using CrossPlatformDesktopProject.Libraries.Container;

namespace CrossPlatformDesktopProject.Libraries.GameStates
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

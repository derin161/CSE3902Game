using SuperMetroidvania5Million.Libraries.Container;
using SuperMetroidvania5Million.Libraries.GameStates;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    public class GameWinMenuCommand : ICommand
    {
        Game1 game;
        public GameWinMenuCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            GameStateMachine.Instance.MenuState(new GameWinMenuState(game));
        }
    }
}


using CrossPlatformDesktopProject.Libraries.Container;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class OpenInGameMenuCommand : ICommand
    {
        public OpenInGameMenuCommand()
        {
        }
        public void Execute()
        {
            GameStateMachine.Instance.InGameMenu();
        }
    }
}

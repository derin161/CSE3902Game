using CrossPlatformDesktopProject.Libraries.Audio;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class UnLoopCurrentThemeCommand : ICommand
    {
        public UnLoopCurrentThemeCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.Controls.UnLoop();
        }
    }
}

using CrossPlatformDesktopProject.Libraries.Audio;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class LoopCurrentThemeCommand : ICommand
    {
        public LoopCurrentThemeCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.Controls.Loop();
        }
    }
}

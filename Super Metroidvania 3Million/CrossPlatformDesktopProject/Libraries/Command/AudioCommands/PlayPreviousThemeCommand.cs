using CrossPlatformDesktopProject.Libraries.Audio;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class PlayPreviousThemeCommand : ICommand
    {
        public PlayPreviousThemeCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.Controls.PlayPreviousTheme();
        }
    }
}

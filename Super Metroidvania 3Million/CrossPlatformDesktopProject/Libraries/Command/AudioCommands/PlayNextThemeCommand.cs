using CrossPlatformDesktopProject.Libraries.Audio;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class PlayNextThemeCommand : ICommand
    {
        public PlayNextThemeCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.Controls.PlayNextTheme();
        }
    }
}

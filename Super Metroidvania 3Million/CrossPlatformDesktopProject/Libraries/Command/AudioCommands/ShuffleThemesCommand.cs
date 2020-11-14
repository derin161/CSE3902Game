using CrossPlatformDesktopProject.Libraries.Audio;
using CrossPlatformDesktopProject.Libraries.CSV;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    public class ShuffleThemesCommand : ICommand
    {
        public ShuffleThemesCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.Controls.Shuffle();
        }
    }
}

using CrossPlatformDesktopProject.Libraries.Audio;
using CrossPlatformDesktopProject.Libraries.CSV;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    public class UnShuffleThemesCommand : ICommand
    {
        public UnShuffleThemesCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.Controls.UnShuffle();
        }
    }
}

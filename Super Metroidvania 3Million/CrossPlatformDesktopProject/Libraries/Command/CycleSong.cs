using CrossPlatformDesktopProject.Libraries.Audio;
using CrossPlatformDesktopProject.Libraries.CSV;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    public class CycleSongCommand : ICommand
    {
        public CycleSongCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.PlayNextSong();
        }
    }
}

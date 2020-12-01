using CrossPlatformDesktopProject.Libraries.Audio;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class LowerSongVolumeCommand : ICommand
    {
        public LowerSongVolumeCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.Controls.LowerVolume();
        }
    }
}

using CrossPlatformDesktopProject.Libraries.Audio;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class RaiseSongVolumeCommand : ICommand
    {
        public RaiseSongVolumeCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.Controls.RaiseVolume();
        }
    }
}

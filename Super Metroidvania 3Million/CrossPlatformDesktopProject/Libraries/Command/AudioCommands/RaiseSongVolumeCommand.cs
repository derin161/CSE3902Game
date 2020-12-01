using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Command
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

using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Command
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

using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
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

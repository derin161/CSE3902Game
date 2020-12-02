using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Command
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

using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Command
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

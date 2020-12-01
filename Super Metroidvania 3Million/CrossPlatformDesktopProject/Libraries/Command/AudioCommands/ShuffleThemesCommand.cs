using CrossPlatformDesktopProject.Libraries.Audio;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
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

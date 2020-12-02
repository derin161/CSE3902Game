using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    public class UnLoopCurrentThemeCommand : ICommand
    {
        public UnLoopCurrentThemeCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.Controls.UnLoop();
        }
    }
}

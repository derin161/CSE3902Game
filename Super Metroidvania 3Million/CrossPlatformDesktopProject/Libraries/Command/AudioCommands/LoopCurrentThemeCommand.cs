using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Command
{
    //Author: Nyigel Spann
    public class LoopCurrentThemeCommand : ICommand
    {
        public LoopCurrentThemeCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.Songs.Controls.Loop();
        }
    }
}

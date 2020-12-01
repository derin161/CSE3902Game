using CrossPlatformDesktopProject.Libraries.Audio;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class LowerEffectVolumeCommand : ICommand
    {
        public LowerEffectVolumeCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.LowerEffectVolume();
        }
    }
}

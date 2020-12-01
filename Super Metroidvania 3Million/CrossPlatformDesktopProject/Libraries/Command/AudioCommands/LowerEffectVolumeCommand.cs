using CrossPlatformDesktopProject.Libraries.Audio;
using CrossPlatformDesktopProject.Libraries.CSV;

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

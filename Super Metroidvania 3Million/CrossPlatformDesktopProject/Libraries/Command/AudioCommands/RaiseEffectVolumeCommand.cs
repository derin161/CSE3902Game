using CrossPlatformDesktopProject.Libraries.Audio;
using CrossPlatformDesktopProject.Libraries.CSV;

namespace CrossPlatformDesktopProject.Libraries.Command
{
    //Author: Nyigel Spann
    public class RaiseEffectVolumeCommand : ICommand
    {
        public RaiseEffectVolumeCommand()
        {
        }
        public void Execute()
        {
            SoundManager.Instance.RaiseEffectVolume();
        }
    }
}

using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Command
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

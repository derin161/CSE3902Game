using SuperMetroidvania5Million.Libraries.Audio;

namespace SuperMetroidvania5Million.Libraries.Command
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

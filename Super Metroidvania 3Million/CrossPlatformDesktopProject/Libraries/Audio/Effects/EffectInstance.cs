using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    //Author: Nyigel Spann
    public class EffectInstance : ISound
    {
        public string Name => effect.Name;
        public double Duration => effect.Duration.TotalMilliseconds;

        private SoundEffect effect;
        public EffectInstance(SoundEffect soundEffect) {
            this.effect = soundEffect;
        }

        public void PlaySound() {
            
             effect.Play(SoundManager.Instance.EffectVolume, 0, 0); //pitch = 0.0f, pan = 0.0f
            
        }
    }
}

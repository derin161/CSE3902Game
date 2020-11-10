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
        
        private SoundEffect sound;
        public EffectInstance(SoundEffect s) {
            this.sound = s;
        }

        public double Duration()
        {
            return sound.Duration.TotalMilliseconds;
        }

        public void PlaySound() {
            
             sound.Play();
            
        }
    }
}

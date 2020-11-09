using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    public class SoundInstance : ISound
    {
        private SoundEffect sound;
        public SoundInstance(SoundEffect s) {
            this.sound = s;
        }

        public void PlaySound() {
            sound.Play();
        }
    }
}

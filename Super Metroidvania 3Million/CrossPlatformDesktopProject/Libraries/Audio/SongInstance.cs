using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Libraries.Audio
{
    public class SongInstance : ISound
    {
        private Song song;
        public SongInstance(Song s) {
            this.song = s;
        }

        public double Duration()
        {
            return song.Duration.TotalMilliseconds;
        }

        public void PlaySound() {
            MediaPlayer.Play(song);
        }


    }
}
